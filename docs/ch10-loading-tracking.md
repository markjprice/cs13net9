**Loading and tracking patterns with EF Core**

- [Eager loading entities using the Include extension method](#eager-loading-entities-using-the-include-extension-method)
- [Enabling lazy loading](#enabling-lazy-loading)
- [Explicit loading entities using the Load method](#explicit-loading-entities-using-the-load-method)
- [Controlling the tracking of entities](#controlling-the-tracking-of-entities)
- [Three tracking scenarios](#three-tracking-scenarios)
- [Lazy loading for no tracking queries](#lazy-loading-for-no-tracking-queries)
- [Summary of tracking](#summary-of-tracking)


There are three loading patterns that are commonly used with EF Core:
- **Eager loading**: Load data early.
- **Lazy loading**: Load data automatically just before it is needed.
- **Explicit loading**: Load data manually.

In this section, we're going to introduce each of them.

# Eager loading entities using the Include extension method

In the `QueryingCategories` method, the code currently uses the `Categories` property to loop through each category, outputting the category name and the number of products in that category.

This works because, when we wrote the query, we enabled eager loading by calling the `Include` method for the related products.

Let's see what happens if we do not call `Include`:
1.	In `Program.Queries.cs`, in the `QueryingCategories` method, modify the query to comment out the `Include` method call, as shown in the following code:
```cs
IQueryable<Category>? categories = db.Categories;
  //.Include(c => c.Products);
```

2.	In `Program.cs`, comment out all method calls except `ConfigureConsole` and `QueryingCategories`.
3.	Run the code and view the result, as shown in the following partial output:
```
Beverages has 0 products.
Condiments has 0 products.
Confections has 0 products.
Dairy Products has 0 products.
Grains/Cereals has 0 products.
Meat/Poultry has 0 products.
Produce has 0 products.
Seafood has 0 products.
```
Each item in `foreach` is an instance of the `Category` class, which has a property named `Products`, that is, the list of products in that category. Since the original query is only selected from the `Categories` table, this property is empty for each category.

# Enabling lazy loading

Lazy loading was introduced in EF Core 2.1, and it can automatically load missing related data. To enable lazy loading, developers must:
- Reference a NuGet package for proxies.
- Configure lazy loading to use a proxy.

Let's see this in action:
1.	In the `WorkingWithEFCore` project, add a package reference for EF Core proxies, as shown in the following markup:
```xml
<PackageReference Version="9.0.0" Include="Microsoft.EntityFrameworkCore.Proxies" />
```

2.	Build the `WorkingWithEFCore` project to restore packages.
3.	In `NorthwindDb.cs`, at the bottom of the `OnConfiguring` method, call an extension method to use lazy loading proxies, as shown in the following code:
```cs
optionsBuilder.UseLazyLoadingProxies();
```

Now, every time the loop enumerates and an attempt is made to read the `Products` property, the lazy loading proxy will check if they are loaded. If they're not loaded, it will load them for us "lazily" by executing a `SELECT` statement to load just that set of products for the current category, and then the correct count will be returned to the output.

4.	Run the code and note that the product counts are now correct. But you will see that the problem with lazy loading is that multiple round trips to the database server are required to eventually fetch all the data. For example, getting all the categories and then getting the products for the first category, `Beverages`, requires the execution of two SQL commands, as shown in the following partial output:
```
dbug: 05/03/2022 13:41:40.221 RelationalEventId.CommandExecuting[20100] (Microsoft.EntityFrameworkCore.Database.Command)
      Executing DbCommand [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT "c"."CategoryId", "c"."CategoryName", "c"."Description"
      FROM "Categories" AS "c"
dbug: 05/03/2022 13:41:40.331 RelationalEventId.CommandExecuting[20100] (Microsoft.EntityFrameworkCore.Database.Command)
      Executing DbCommand [Parameters=[@__p_0='1'], CommandType='Text', CommandTimeout='30']
      SELECT "p"."ProductId", "p"."CategoryId", "p"."UnitPrice", "p"."Discontinued", "p"."ProductName", "p"."UnitsInStock"
      FROM "Products" AS "p"
      WHERE NOT ("p"."Discontinued") AND "p"."CategoryId" = @__p_0
Beverages has 11 products.
...
```

# Explicit loading entities using the Load method

Another type of loading is explicit loading. It works in a similar way to lazy loading, with the difference being that you are in control of exactly what related data is loaded and when:
1.	At the top of `Program.Queries.cs`, import the change tracking namespace to enable us to use the `CollectionEntry` class to manually load related entities, as shown in the following code:
```cs
// To use CollectionEntry.
using Microsoft.EntityFrameworkCore.ChangeTracking;
```

2.	In `QueryingCategories`, modify the statements to disable lazy loading and then prompt the user as to whether they want to enable eager loading and explicit loading, as shown in the following code:
```cs
IQueryable<Category>? categories;
  // = db.Categories;
  // .Include(c => c.Products);

db.ChangeTracker.LazyLoadingEnabled = false;

Write("Enable eager loading? (Y/N): ");
bool eagerLoading = (ReadKey().Key == ConsoleKey.Y);
bool explicitLoading = false;
WriteLine();

if (eagerLoading)
{
  categories = db.Categories?.Include(c => c.Products);
}
else
{
  categories = db.Categories;
  Write("Enable explicit loading? (Y/N): ");
  explicitLoading = (ReadKey().Key == ConsoleKey.Y);
  WriteLine();
}
```

3.	In the `foreach` loop, before the `WriteLine` method call, add statements to check if explicit loading is enabled, and if so, prompt the user as to whether they want to explicitly load each individual category, as shown in the following code:
```cs
if (explicitLoading)
{
  Write($"Explicitly load products for {c.CategoryName}? (Y/N): ");
  ConsoleKeyInfo key = ReadKey();
  WriteLine();

  if (key.Key == ConsoleKey.Y)
  {
    CollectionEntry<Category, Product> products =
      db.Entry(c).Collection(c2 => c2.Products);

    if (!products.IsLoaded) products.Load();
  }
}
```

4.	Run the code:
    - Press *N* to disable eager loading.
    - Then, press *Y* to enable explicit loading.
    - For each category, press *Y* or *N* to load its products as you wish.

I chose to load products for only two of the eight categories, `Beverages` and `Seafood`, as shown in the following output, which has been edited for space:
```
Enable eager loading? (Y/N): n
Enable explicit loading? (Y/N): y
dbug: 05/03/2023 13:48:48.541 RelationalEventId.CommandExecuting[20100] (Microsoft.EntityFrameworkCore.Database.Command)
      Executing DbCommand [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT "c"."CategoryId", "c"."CategoryName", "c"."Description"
      FROM "Categories" AS "c"
Explicitly load products for Beverages? (Y/N): y
dbug: 05/03/2023 13:49:07.416 RelationalEventId.CommandExecuting[20100] (Microsoft.EntityFrameworkCore.Database.Command)
      Executing DbCommand [Parameters=[@__p_0='1'], CommandType='Text', CommandTimeout='30']
      SELECT "p"."ProductId", "p"."CategoryId", "p"."UnitPrice", "p"."Discontinued", "p"."ProductName", "p"."UnitsInStock"
      FROM "Products" AS "p"
      WHERE NOT ("p"."Discontinued") AND "p"."CategoryId" = @__p_0
Beverages has 11 products.
Explicitly load products for Condiments? (Y/N): n
Condiments has 0 products.
Explicitly load products for Confections? (Y/N): n
Confections has 0 products.
Explicitly load products for Dairy Products? (Y/N): n
Dairy Products has 0 products.
Explicitly load products for Grains/Cereals? (Y/N): n
Grains/Cereals has 0 products.
Explicitly load products for Meat/Poultry? (Y/N): n
Meat/Poultry has 0 products.
Explicitly load products for Produce? (Y/N): n
Produce has 0 products.
Explicitly load products for Seafood? (Y/N): y
dbug: 05/03/2023 13:49:16.682 RelationalEventId.CommandExecuting[20100] (Microsoft.EntityFrameworkCore.Database.Command)

      Executing DbCommand [Parameters=[@__p_0='8'], CommandType='Text', CommandTimeout='30']
      SELECT "p"."ProductId", "p"."CategoryId", "p"."UnitPrice", "p"."Discontinued", "p"."ProductName", "p"."UnitsInStock"
      FROM "Products" AS "p"
      WHERE NOT ("p"."Discontinued") AND "p"."CategoryId" = @__p_0
Seafood has 12 products.
```

> **Good Practice**: Carefully consider which loading pattern is best for your code. Lazy loading could literally make you a lazy database developer! Read more about loading patterns at the following link: https://learn.microsoft.com/en-us/ef/core/querying/related-data.

# Controlling the tracking of entities

We need to start with the definition of entity identity resolution. EF Core resolves each entity instance by reading its unique primary key value. This ensures no ambiguities about the identities of entities or relationships between them.

By default, EF Core assumes that you want to track entities in local memory so that if you make changes, like adding a new entity, modifying an existing entity, or removing an existing entity, then you can call `SaveChanges` and all those changes will be made in the underlying data store.

EF Core can only track entities with keys because it uses the key to uniquely identify the entity in the database. Keyless entities, like those returned by views, are never tracked in any scenario.

In the Northwind database, in the `Customers` table, there is a customer, as shown in the following record:
```
CustomerId: ALFKI
CompanyName: Alfreds Futterkiste
Country: Germany
Phone: 030-0074321
```

If you execute a query within a data context, like getting all customers in `Germany`, and then execute another query within the same data context, like getting all customers whose name starts with `A`, if one of those customer entities already exists in the context, it will be identified and not loaded again, which improves performance.

However, if the telephone number of that customer is updated in the database between the executions of the two queries, then the entity being tracked in the data context is not refreshed with the new telephone number.

If you do not need to track local changes, or you want to load new instances of an entity for every query execution with the latest data values, even if the entity is already loaded, then you can disable tracking.

To disable tracking for an individual query, call the `AsNoTracking` method as part of the query, as shown in the following code:
```cs
var products = db.Products
  .AsNoTracking()
  .Where(p => p.UnitPrice > price)
  .Select(p => new { p.ProductId, p.ProductName, p.UnitPrice });
```

To disable tracking by default for an instance of a data context, set the change tracker's query-tracking behavior to NoTracking, as shown in the following code:
```cs
db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
```

To disable tracking for an individual query but retain identity resolution, call the AsNoTrackingWithIdentityResolution method as part of the query, as shown in the following code:
```cs
var products = db.Products
  .AsNoTrackingWithIdentityResolution()
  .Where(p => p.UnitPrice > price)
  .Select(p => new { p.ProductId, p.ProductName, p.UnitPrice });
```

To disable tracking but perform identity resolution by default for an instance of a data context, set the change tracker's query tracking behavior to `NoTrackingWithIdentityResolution`, as shown in the following code:
```cs
db.ChangeTracker.QueryTrackingBehavior =
  QueryTrackingBehavior.NoTrackingWithIdentityResolution;
```

To set defaults for all new instances of a data context, in its `OnConfiguring` method, call the `UseQueryTrackingBehavior` method, as shown in the following code:
```cs
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
  optionsBuilder.UseSqlite(connectionString)
    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
}
```

# Three tracking scenarios

First, let's review a scenario using default tracking. The default is tracking with identity resolution. Once an entity is loaded into the data context, underlying changes are not reflected and only one copy exists locally. Entities have local changes tracked and a call to SaveChanges updates the database. Actions and states for scenario 1 are illustrated in *Table 10.4*:

Action|Entity in data context|Row in database
---|---|---
Query for customers in Germany|Alfreds Futterkiste, 030-7432|Alfreds Futterkiste, 030-7432
Change telephone in database|Alfreds Futterkiste, 030-7432|Alfreds Futterkiste, 030-9876
Query for customers starting with A|Alfreds Futterkiste, 030-7432|Alfreds Futterkiste, 030-9876
Query for customers in Germany|Alfreds Futterkiste, 030-7432|Alfreds Futterkiste, 030-9876
Change telephone in local entity|Alfreds Futterkiste, 030-1928|Alfreds Futterkiste, 030-9876
Save changes|Alfreds Futterkiste, 030-1928|Alfreds Futterkiste, 030-1928

*Table 10.4: Scenario 1, change tracking with identity resolution*

Second, let's compare the same set of actions using no tracking and no identity resolution. Every query loads another instance of a database row into the data context, including underlying changes, allowing duplicates and mixed out-of-date and updated data. No local entity changes are tracked, so `SaveChanges` does nothing. Actions and states for scenario 2 are illustrated in *Table 10.5*:

Action|Entities in data context|Row in database
---|---|---
Query for customers in Germany|Alfreds Futterkiste, 030-7432|Alfreds Futterkiste, 030-7432
Change telephone in database|Alfreds Futterkiste, 030-7432|Alfreds Futterkiste, 030-9876
Query for customers starting with A|Alfreds Futterkiste, 030-7432<br/>Alfreds Futterkiste, 030-9876|Alfreds Futterkiste, 030-9876
Query for customers in Germany|Alfreds Futterkiste, 030-7432<br/>Alfreds Futterkiste, 030-9876<br/>Alfreds Futterkiste, 030-9876|Alfreds Futterkiste, 030-9876
Change telephone in local entity|Alfreds Futterkiste, 030-7432<br/>Alfreds Futterkiste, 030-9876<br/>Alfreds Futterkiste, 030-1928|Alfreds Futterkiste, 030-9876
Save changes|Alfreds Futterkiste, 030-7432<br/>Alfreds Futterkiste, 030-9876<br/>Alfreds Futterkiste, 030-1928|Alfreds Futterkiste, 030-9876

*Table 10.5: Scenario 2, no change tracking with no identity resolution*

Third, let's compare the same set of actions using no tracking with identity resolution. Once an entity is loaded into the data context, underlying changes are not reflected and only one copy exists. No local entity changes are tracked, so `SaveChanges` does nothing. Actions and states for scenario 3 are illustrated in *Table 10.6*:

Action|Entities in data context|Row in database
---|---|---
Query for customers in Germany|Alfreds Futterkiste, 030-7432|Alfreds Futterkiste, 030-7432
Change telephone in database|Alfreds Futterkiste, 030-7432|Alfreds Futterkiste, 030-9876
Query for customers starting with A|Alfreds Futterkiste, 030-7432|Alfreds Futterkiste, 030-9876
Query for customers in Germany|Alfreds Futterkiste, 030-7432|Alfreds Futterkiste, 030-9876
Change telephone in local entity|Alfreds Futterkiste, 030-1928|Alfreds Futterkiste, 030-9876
Save changes|Alfreds Futterkiste, 030-1928|Alfreds Futterkiste, 030-9876

*Table 10.6: Scenario 3, no change tracking with identity resolution*

# Lazy loading for no tracking queries

In EF Core 7 or earlier, if you enable no tracking, then you cannot use the lazy loading pattern. If you try, then you will see the following exception at runtime:
```
Unhandled exception. System.InvalidOperationException: An error was generated for warning 'Microsoft.EntityFrameworkCore.Infrastructure.DetachedLazyLoadingWarning': An attempt was made to lazy-load navigation 'Category' on a detached entity of type 'ProductProxy'. Lazy loading is not supported for detached entities or entities that are loaded with 'AsNoTracking'. This exception can be suppressed or logged by passing event ID 'CoreEventId.DetachedLazyLoadingWarning' to the 'ConfigureWarnings' method in 'DbContext.OnConfiguring' or 'AddDbContext'.
```

EF Core 8 enabled support for the lazy loading of entities that are not being tracked.

Let's try an example:
1.	In `Program.Queries.cs`, add a method to request a no tracking query for products, and when you enumerate the products, use lazy loading to fetch the related category name, as shown in the following code:
```cs
private static void LazyLoadingWithNoTracking()
{
  using NorthwindDb db = new();

  SectionTitle("Lazy-loading with no tracking");

  IQueryable<Product>? products = db.Products?.AsNoTracking();

  if (products is null || !products.Any())
  {
    Fail("No products found.");
    return;
  }

  foreach (Product p in products)
  {
    WriteLine("{0} is in category named {1}.",
      p.ProductName, p.Category.CategoryName);
  }
}
```

2.	In `Program.cs`, add a call to `LazyLoadingWithNoTracking`. You might want to comment out any other method calls except `ConfigureConsole`, which ensures you see the same currency and other formatting as shown in the book.
3.	Run the code and note that it works without throwing an exception as it would have done with previous versions of EF Core.

> If you want to see the runtime exception for yourself, in the project file, change the version numbers of the three EF Core packages from `9.0.0` to any package version older than `8.0.0`, like `7.0.0` or `6.0.0`.

# Summary of tracking

Which should you choose? Of course, it depends on your specific scenarios.

You will sometimes read blogs or LinkedIn posts that excitedly tell you that "no one knows this one amazing trick to dramatically improve your EF Core queries" by calling `AsNoTracking`. But if you run a query that returns thousands of entities, and then run the same query again within the same data context, you'll now have thousands of duplicates! This wastes memory and negatively impacts performance, so the advice to "call `AsNoTracking`" to improve performance is not always true.

Understand how the three tracking choices work and select the best for your data context or individual queries.
