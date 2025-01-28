**Modifying data with EF Core**

- [Inserting entities](#inserting-entities)
- [Updating entities](#updating-entities)
- [Deleting entities](#deleting-entities)
- [More efficient updates and deletes](#more-efficient-updates-and-deletes)
- [Pooling database contexts](#pooling-database-contexts)


Inserting, updating, and deleting entities using EF Core is an easy task to accomplish. This is often referred to as **CRUD**, an acronym that includes the following operations:
- C for Create
- R for Retrieve (or Read)
- U for Update
- D for Delete

By default, `DbContext` maintains change tracking automatically, so the local entities can have multiple changes tracked, including adding new entities, modifying existing entities, and removing entities.

When you are ready to send those changes to the underlying database, call the SaveChanges method. The number of entities successfully changed will be returned.

# Inserting entities

Let's start by looking at how to add a new row to a table:
1.	In the `WorkingWithEFCore` project, add a new class file named `Program.Modifications.cs`.
2.	In `Program.Modifications.cs`, create a `partial Program` class with a method named `ListProducts` that outputs the ID, name, cost, stock, and discontinued properties of each product, sorted with the costliest first, and highlights any that match an array of `int` values that can be optionally passed to the method, as shown in the following code:
```cs
using Microsoft.EntityFrameworkCore; // To use ExecuteUpdate, ExecuteDelete.
using Microsoft.EntityFrameworkCore.ChangeTracking; // To use EntityEntry<T>.
using Northwind.EntityModels; // To use Northwind, Product.

partial class Program
{
  private static void ListProducts(
    int[]? productIdsToHighlight = null)
  {
    using NorthwindDb db = new();

    if (db.Products is null || !db.Products.Any())
    {
      Fail("There are no products.");
      return;
    }

    WriteLine("| {0,-3} | {1,-35} | {2,8} | {3,5} | {4} |",
      "Id", "Product Name", "Cost", "Stock", "Disc.");

    foreach (Product p in db.Products)
    {
      ConsoleColor previousColor = ForegroundColor;

      if (productIdsToHighlight is not null &&
        productIdsToHighlight.Contains(p.ProductId))
      {
        ForegroundColor = ConsoleColor.Green;
      }

      WriteLine("| {0:000} | {1,-35} | {2,8:$#,##0.00} | {3,5} | {4} |",
        p.ProductId, p.ProductName, p.Cost, p.Stock, p.Discontinued);

      ForegroundColor = previousColor;
    }
  }
}
```

> Remember that `{1,-35}` means *left-align argument 1 within a 35-character-wide column*, and `{3,5}` means *right-align argument 3 within a 5-character-wide column*.

3.	In `Program.Modifications.cs`, add a method named `AddProduct` that returns a two-integer tuple, as shown in the following code:
```cs
private static (int affected, int productId) AddProduct(
  int categoryId, string productName, decimal? price, short? stock)
{
  using NorthwindDb db = new();

  if (db.Products is null) return (0, 0);

  Product p = new()
  {
    CategoryId = categoryId,
    ProductName = productName,
    Cost = price,
    Stock = stock
  };

  // Set product as added in change tracking.
  EntityEntry<Product> entity = db.Products.Add(p);

  // Alternatively, call Add<Product> on the data context.
  // EntityEntry<Product> entity = db.Add(p);

  WriteLine($"State: {entity.State}, ProductId: {p.ProductId}");

  // Save tracked change to database.
  int affected = db.SaveChanges();
  WriteLine($"State: {entity.State}, ProductId: {p.ProductId}");

  return (affected, p.ProductId);
}
```

4.	In `Program.cs`, comment out previous method calls, and then call `AddProduct` and `ListProducts`, as shown in the following code:
```cs
var resultAdd = AddProduct(categoryId: 6,
  productName: "Bob's Burgers", price: 500M, stock: 72);

if (resultAdd.affected == 1)
{
  WriteLine($"Add product successful with ID: {resultAdd.productId}.");
}

ListProducts(productIdsToHighlight: new[] { resultAdd.productId });
```

5.	Run the code, view the result, and note the new product has been added, as shown in the following partial output:
```
State: Added, ProductId: 0
dbug: 05/03/2022 14:21:37.818 RelationalEventId.CommandExecuting[20100] (Microsoft.EntityFrameworkCore.Database.Command)
      Executing DbCommand [Parameters=[@p0='6', @p1='500' (Nullable = true), @p2='False', @p3='Bob's Burgers' (Nullable = false) (Size = 13), @p4=NULL (DbType = Int16)], CommandType='Text', CommandTimeout='30']
      INSERT INTO "Products" ("CategoryId", "UnitPrice", "Discontinued", "ProductName", "UnitsInStock")
      VALUES (@p0, @p1, @p2, @p3, @p4);
      SELECT "ProductId"
      FROM "Products"
      WHERE changes() = 1 AND "rowid" = last_insert_rowid();
State: Unchanged, ProductId: 78
Add product successful with ID: 78.
| Id  | Product Name                        |     Cost | Stock | Disc. |
| 001 | Chai                                |   $18.00 |    39 | False |
| 002 | Chang                               |   $19.00 |    17 | False |
...
| 078 | Bob's Burgers                       |  $500.00 |    72 | False |
```

When the new product is first created in memory and tracked by the EF Core change tracker, it has a state of `Added` and its ID is `0`. After the call to `SaveChanges`, it has a state of `Unchanged` and its ID is `78`, the value assigned by the database.

> **Warning!** As you can see from the output, it was executed on 05/03/2022. Since then, the EF Core SQLite team may have improved the generated SQL, or if you use a different EF Core data provider, then the generated SQL could be different, for example, as shown in the following SQL:
```sql
INSERT INTO "Products" ("CategoryId", "UnitPrice", "Discontinued",
"ProductName", "UnitsInStock")
VALUES (@p0, @p1, @p2, @p3, @p4);
RETURNING "ProductId";
```

# Updating entities

Now, let's modify an existing row in a table.

We will find a product to update by specifying the start of a product name and only return the first match. In a real application, if you need to update a specific product, then you must use a unique identifier like `ProductId`.

> I do not know what the product ID will be for the products that you add. I do know that there are no products that start with "Bob" in the existing Northwind database. Finding a product to update using its name avoids having to tell you to first discover what the product ID is for a product that you've added. It is likely to be `78` because there are already `77` products in the table, but once you've added that and then deleted it, the next product to be added could be `79` and it all gets out of sync. It depends on the data provider. Some are "smart" so they could decrement their internal counter to reuse 78 again for a new row. The point is that you should not make any assumptions about database-assigned values.

Let's go:
1.	In `Program.Modifications.cs`, add a method to increase the price of the first product with a name that begins with a specified value (we'll use `Bob` in our example) by a specified amount, like $20, as shown in the following code:
```cs
private static (int affected, int productId) IncreaseProductPrice(
  string productNameStartsWith, decimal amount)
{
  using NorthwindDb db = new();

  if (db.Products is null) return (0, 0);

  // Get the first product whose name starts with the parameter value.
  Product updateProduct = db.Products.First(
    p => p.ProductName.StartsWith(productNameStartsWith));

  updateProduct.Cost += amount;

  int affected = db.SaveChanges();
  return (affected, updateProduct.ProductId);
}
```

7.	In `Program.cs`, comment out the statements to add a new product, and then add statements to call `IncreaseProductPrice` and then `ListProducts`, as shown in the following code:
```cs
var resultUpdate = IncreaseProductPrice(
  productNameStartsWith: "Bob", amount: 20M);

if (resultUpdate.affected == 1)
{
  WriteLine($"Increase price success for ID: {resultUpdate.productId}.");
}

ListProducts(productIdsToHighlight: new[] { resultUpdate.productId });
```

8.	Run the code, view the result, and note that the existing entity for `Bob's Burgers` has increased in price by $20, as shown in the following partial output:
```
dbug: 05/03/2022 14:44:47.024 RelationalEventId.CommandExecuting[20100] (Microsoft.EntityFrameworkCore.Database.Command)

      Executing DbCommand [Parameters=[@__productNameStartsWith_0='Bob' (Size = 3)], CommandType='Text', CommandTimeout='30']
      SELECT "p"."ProductId", "p"."CategoryId", "p"."UnitPrice", "p"."Discontinued", "p"."ProductName", "p"."UnitsInStock"
      FROM "Products" AS "p"
      WHERE NOT ("p"."Discontinued") AND (@__productNameStartsWith_0 = '' OR (("p"."ProductName" LIKE @__productNameStartsWith_0 || '%') AND substr("p"."ProductName", 1, length(@__productNameStartsWith_0)) = @__productNameStartsWith_0) OR @__productNameStartsWith_0 = '')
      LIMIT 1
dbug: 05/03/2022 14:44:47.028 RelationalEventId.CommandExecuting[20100] (Microsoft.EntityFrameworkCore.Database.Command)

      Executing DbCommand [Parameters=[@p1='78', @p0='520' (Nullable = true)], CommandType='Text', CommandTimeout='30']
      UPDATE "Products" SET "UnitPrice" = @p0
      WHERE "ProductId" = @p1;
      SELECT changes();
Increase price success for ID: 78.
| Id  | Product Name                        |     Cost | Stock | Disc. |
| 001 | Chai                                |   $18.00 |    39 | False |
...
| 078 | Bob's Burgers                       |  $520.00 |    72 | False |
```

# Deleting entities

You can remove individual entities with the `Remove` method. `RemoveRange` is more efficient when you want to delete multiple entities.

Let's see how to delete rows from a table:
1.	In `Program.Modifications.cs`, add a method to delete all products with a name that begins with a specified value (`Bob` in our example), as shown in the following code:
```cs
private static int DeleteProducts(string productNameStartsWith)
{
  using NorthwindDb db = new();

  IQueryable<Product>? products = db.Products?.Where(
    p => p.ProductName.StartsWith(productNameStartsWith));

  if (products is null || !products.Any())
  {
    WriteLine("No products found to delete.");
    return 0;
  }
  else
  {
    if (db.Products is null) return 0;
    db.Products.RemoveRange(products);
  }

  int affected = db.SaveChanges();
  return affected;
}
```

2.	In `Program.cs`, comment out the statements to update the product, and then add statements to call `DeleteProducts`, as shown in the following code:
```cs
WriteLine("About to delete all products whose name starts with Bob.");
Write("Press Enter to continue or any other key to exit: ");
if (ReadKey(intercept: true).Key == ConsoleKey.Enter)
{
  int deleted = DeleteProducts(productNameStartsWith: "Bob");
  WriteLine($"{deleted} product(s) were deleted.");
}
else
{
  WriteLine("Delete was canceled.");
}
```

3.	Run the code, press *Enter*, and view the result, as shown in the following partial output:
```
1 product(s) were deleted.
```

If multiple product names started with `Bob`, then they would all be deleted. As an optional challenge, modify the statements to add three new products that start with `Bob` and then delete them.

# More efficient updates and deletes

You have now seen the traditional way of modifying data using EF Core, as summarized in the following steps:
1.	Create a database context. Change tracking is enabled by default.
2.	To insert data, create a new instance of an entity class and then pass it as an argument to the `Add` method of the appropriate collection, for example, `db.Products.Add(product)`, or directly on the data context, for example, `db.Add(product)`. The `Add<T>` method is generic so it knows what type of entity is being added and therefore which table to add it to. 
3.	To update data, retrieve the entities that you want to modify and then change their properties.
4.	To delete data, retrieve the entities that you want to remove and then pass them as an argument to the `Remove` or `RemoveRange` methods of the appropriate collection, for example, `db.Products.Remove(product)`.
5.	Call the `SaveChanges` method of the database context. This uses the change tracker to generate SQL statements to perform the needed inserts, updates, and deletes, and then returns the number of entities affected.

EF Core 7 introduced two methods that can make updates and deletes more efficient because they do not require entities to be loaded into memory and have their changes tracked. The methods are named `ExecuteDelete` and `ExecuteUpdate` (and their `...Async` equivalents). They are called on a LINQ query and affect the entities in the query result, although the query is not used to retrieve entities, so no entities are loaded into the data context.

For example, to delete all products, call the `ExecuteDelete` or `ExecuteDeleteAsync` method on any table, as shown in the following code:
```cs
await db.Products.ExecuteDeleteAsync();
```

The preceding code would execute an SQL statement in the database, as shown in the following code:
```sql
DELETE FROM Products
```

To delete all products that have a unit price greater than 50, use the following code:
```cs
await db.Products
  .Where(product => product.UnitPrice > 50)
  .ExecuteDeleteAsync();
```

The preceding code would execute an SQL statement in the database, as shown in the following code:
```sql
DELETE FROM Products p WHERE p.UnitPrice > 50
```

`ExecuteUpdate` and `ExecuteDelete` can only act on a single table, so although you can write quite complex LINQ queries, they can only update or delete from a single table.

To update all products that are not discontinued to increase their unit price by 10% due to inflation, use the following code:
```cs
await db.Products
  .Where(product => !product.Discontinued)
  .ExecuteUpdateAsync(s => s.SetProperty(
    p => p.UnitPrice, // Selects the property to update.
    p => p.UnitPrice * 1.1)); // Sets the value to update it to.
```

You can chain multiple calls to `SetProperty` in the same query to update multiple properties in one command.

Let's see some examples:
1.	In `Program.Modifications.cs`, add a method to update all products with a name that begins with a specified value using `ExecuteUpdate`, as shown in the following code:
```cs
private static (int affected, int[]? productIds)
  IncreaseProductPricesBetter(
  string productNameStartsWith, decimal amount)
{
  using NorthwindDb db = new();

  if (db.Products is null) return (0, null);

  // Get products whose name starts with the parameter value.
  IQueryable<Product>? products = db.Products.Where(
    p => p.ProductName.StartsWith(productNameStartsWith));

  int affected = products.ExecuteUpdate(s => s.SetProperty(
    p => p.Cost, // Property selector lambda expression.
    p => p.Cost + amount)); // Value to update to lambda expression.

  int[] productIds = products.Select(p => p.ProductId).ToArray();

  return (affected, productIds);
}
```

2.	In `Program.cs`, comment out the statements to delete products, and then add statements to call `IncreaseProductPricesBetter`, as shown in the following code:
```cs
var resultUpdateBetter = IncreaseProductPricesBetter(
  productNameStartsWith: "Bob", amount: 20M);

if (resultUpdateBetter.affected > 0)
{
  WriteLine("Increase product price successful.");
}

ListProducts(productIdsToHighlight: resultUpdateBetter.productIds);
```

3.	Uncomment the statements that add a new product.
4.	Run the console app multiple times and note that, each time, the existing products with the `Bob` prefix are each updated with an incrementing cost, as shown in the following output:
```
...
| 078 | Bob's Burgers                       |  $560.00 |    72 | False |
| 079 | Bob's Burgers                       |  $540.00 |    72 | False |
| 080 | Bob's Burgers                       |  $520.00 |    72 | False |
```

5.	In `Program.Modifications.cs`, add a method to delete any products with a name that begins with a specified value using `ExecuteDelete`, as shown in the following code:
```cs
private static int DeleteProductsBetter(
  string productNameStartsWith)
{
  using NorthwindDb db = new();

  int affected = 0;

  IQueryable<Product>? products = db.Products?.Where(
    p => p.ProductName.StartsWith(productNameStartsWith));

  if (products is null || !products.Any())
  {
    WriteLine("No products found to delete.");
    return 0;
  }
  else
  {
    affected = products.ExecuteDelete();
  }
  return affected;
}
```

6.	In `Program.cs`, comment out previous method calls except `ConfigureConsole`, and then add statements to call `DeleteProductsBetter`, as shown in the following code:
```cs
WriteLine("About to delete all products whose name starts with Bob.");
Write("Press Enter to continue or any other key to exit: ");
if (ReadKey(intercept: true).Key == ConsoleKey.Enter)
{
  int deleted = DeleteProductsBetter(productNameStartsWith: "Bob");
  WriteLine($"{deleted} product(s) were deleted.");
}
else
{
  WriteLine("Delete was canceled.");
}
```

7.	Run the console app and confirm that the products are deleted, as shown in the following output:
```
3 product(s) were deleted.
```

> **Warning!** If you mix traditional tracked changes with the `ExecuteUpdate` and `ExecuteDelete` methods, then note that they are not kept synchronized. The change tracker will not know what you have updated and deleted using those methods.

# Pooling database contexts

The `DbContext` class is disposable and is designed following the single-unit-of-work principle. In the previous code examples, we created all the `DbContext`-derived `NorthwindDb` instances in a using block so that `Dispose` is properly called at the end of each unit of work.

A feature of ASP.NET Core that is related to EF Core is that it makes your code more efficient by pooling database contexts when building websites and services. This allows you to create and dispose of as many `DbContext`-derived objects as you want, knowing that your code is still as efficient as possible.
