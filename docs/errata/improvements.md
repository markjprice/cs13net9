**Improvements** (11 items)

If you have suggestions for improvements, then please [raise an issue in this repository](https://github.com/markjprice/cs13net9/issues) or email me at markjprice (at) gmail.com.

- [Introducing C# and .NET](#introducing-c-and-net)
- [Page 15 - Listing and removing versions of .NET](#page-15---listing-and-removing-versions-of-net)
- [Page 20 - Compiling and running code using Visual Studio](#page-20---compiling-and-running-code-using-visual-studio)
- [Page 38 - Getting definitions of types and their members](#page-38---getting-definitions-of-types-and-their-members)
- [Page 438 - Examples of regular expressions](#page-438---examples-of-regular-expressions)
- [Page 439 - Splitting a complex comma-separated string](#page-439---splitting-a-complex-comma-separated-string)
- [Page 467 - Good practice with collections](#page-467---good-practice-with-collections)
- [Page 488 - Controlling how you work with files](#page-488---controlling-how-you-work-with-files)
- [Chapter 10 - Working with Data Using Entity Framework Core](#chapter-10---working-with-data-using-entity-framework-core)
- [Page 752 - Creating data repositories with caching for entities](#page-752---creating-data-repositories-with-caching-for-entities)
- [Appendix - Exercise 3.1 – Test your knowledge](#appendix---exercise-31--test-your-knowledge)

# Introducing C# and .NET

> Thanks to **eddyyxxyy** in the book's Discord channel for asking a question that prompted this improvement item.

Throughout the book I introduce C# and .NET and how they are related, but this information is spread over multiple chapters. Readers who are completely new to the technologies might still have some questions like "if theres ways of building C# programs without .NET". In the next edition, I will start *Chapter 1* with a brief introduction of C# and .NET and how they are related, as shown in the following text and figure:

C# and .NET are closely related technologies. C# is a programming language that compiles to **Common Intermediate Language (CIL)** aka IL code. IL code can then be loaded by the **Common Language Runtime (CLR)** that is part of the .NET Runtime and **Just In Time (JIT)** compiled to native CPU instructions aka machine code that are executed by your computer. There are other languages like **Visual Basic .NET** and **F#** that can also be compiled to IL code, so they are alternatives to C# that can create .NET projects. 

![Architecture of .NET](https://dotnet.microsoft.com/blob-assets/images/illustrations/swimlane-architecture-framework.svg)

You can build .NET projects without C#, but C# can only build projects for .NET. In theory, since C# is an open standard, someone could create a C# compiler that builds projects for other platforms, but in practice, no one has done this. 

If you are a C# programmer then you always build .NET projects. If you are a .NET programmer, then you most likely use C#, or you could use F# or Visual Basic. Despite Microsoft's support for multiple languages within the .NET ecosystem, including C#, F#, and Visual Basic, C# has maintained a dominant position. According to JetBrains' 2023 Developer Ecosystem survey, 99% of .NET developers use C#, while 7% use Visual Basic, and 3% use F#. While F# and Visual Basic have their dedicated user bases and specific use cases, C# remains the overwhelmingly preferred language among .NET developers.

# Page 15 - Listing and removing versions of .NET

> Thanks to [s3ba-b](https://github.com/s3ba-b) who raised this [issue on November 5, 2024](https://github.com/markjprice/cs12dotnet8/issues/75).

In the first paragraph I wrote, ".NET runtime updates are compatible with a major version such as 8.x, and updated releases of the .NET SDK maintain the ability to build applications that target previous versions of the runtime, which enables the safe removal of older versions."

This could be clearer, so in the 10th edition*, I will write soemthing like: 

"All future versions of the .NET 10 runtime are compatible with its major version. For example, if a project targets `net10.0`, then you can upgrade the .NET runtime to future versions like `10.0.1`, `10.0.2`, and so on. In fact, you *must* upgrade the .NET runtime every month to maintain support."

"All future versions of the .NET SDK maintain the ability to build projects that target previous versions of the runtime. For example, if a project targets `net10.0` and you initially build it using .NET SDK `10.0.100`, then you can upgrade the .NET SDK to future bug fix versions like `10.0.101` or a major version like `11.0.100`, and that SDK can still build the project for the older targetted version. This means that you can safely remove all older versions of any .NET SDKs like `8.0.100`, `9.0.100`, or `10.0.100`, after you've installed a .NET SDK 11 or later. You will still be able to build all your old projects that target those older versions."

*It was too late to make this improvement in the 9th edition. 

# Page 20 - Compiling and running code using Visual Studio

> Thanks to Phil who sent an email on November 11, 2024, asking a question that prompted this improvement.

*Figure 1.5* shows the result of running the console app in Visual Studio, as shown in the following screenshot:
![Microsoft Visual Studio Debug Console in Windows Terminal](page-20-console-2.png)
*Figure 1.5*

A reader completed this section but their command window looked different, as shown in the following screenshot:
![Microsoft Visual Studio Debug Console by default](page-20-console-1.jpg)

Note that it would look more similar if the window was resized and the window was configured with different colors: black text on a white background instead of the opposite. 

> To change colors with this old command prompt app, click the top-left icon, and then in the menu, click **Properties**. You will see tabs to change **Colors**, **Font**, and so on.

You can also install and use alternative command prompts or terminals. For example, I installed **Windows Terminal** several years ago because it has several benefits:
- It makes it extra easy to change color schemes. For example, instead of the default white text on a black background, my publisher prefers black text on white background (at least in screenshots!) because they look better when printed in a book.
- It supports tabs so you can easily manage multiple active consoles simultaneously.
- It still uses the builtin `cmd.exe` so the output is the same as the default.

Since October 2022, Windows Terminal is the default in Windows 11 so you should not need to install it. But if you use an older version of Windows, then you can install Windows Terminal from the Microsoft Store. 

> **More Information**: You can learn more about Windows Terminal at the following link: https://devblogs.microsoft.com/commandline/windows-terminal-is-now-the-default-in-windows-11/.

In the next edition, I might add notes about this.

# Page 38 - Getting definitions of types and their members

> Thanks to **not_a_pigeon1277** in the book's Discord channel for documenting this improvement.

If you try to use the **Go To Definition** feature in VS Code and you get a `Request textDocument/definition failed.` error then disable the **Navigate to Source Link and And Embedded Sources** feature, as described in the following steps:

1. Navigate to **Settings** | **C#** | **Text Editor**.
2. Clear the **Navigate to Source Link and And Embedded Sources** check box, as shown in the following screenshot:

![Clearing the Navigate to Source Link and And Embedded Sources setting](page-38-disable-setting.png)
*Clearing the **Navigate to Source Link and And Embedded Sources** setting*

# Page 438 - Examples of regular expressions

> Thanks to **rene** in the book's Discord channel for suggesting this improvement.

*Table 8.8* shows some examples of regular expressions with descriptions of their meaning. The last two entries are:

Expression|Meaning
---|---
`^d.g$`|The letter `d`, then any character, and then the letter `g`, so it would match both `dig` and `dog` or any single character between the `d` and `g`
`^d\.g$`|The letter `d`, then a dot `.`, and then the letter `g`, so it would match `d.g` only

**rene** suggested "adding `^d.+g$` and/or `^d.*g$` ... so it would match `dingdong`." 

I like that idea, so in the 10th edition I will add that example to the table.

# Page 439 - Splitting a complex comma-separated string

> Thanks to **Chip** who sent an email about this issue on December 13, 2024.

In Step 1, I wrote, "Add statements to store a complex comma-separated string variable", and in the code there is a statement to sets that variable to a CSV string, as shown in the following code:
```cs
string films = """
"Monsters, Inc.","I, Tonya","Lock, Stock and Two Smoking Barrels"
""";
```

But at least one reader added extra spaces after the commas between the double-quoted movie titles, as shown in the following code:
```cs
string films = """
"Monsters, Inc.", "I, Tonya", "Lock, Stock and Two Smoking Barrels"
extra spaces ----^ ----------^
```
Doing this means the variable contains comma-and-space-separated values instead of purely comma-separated values. The regular expression was written to process only literally CSV values with no whitespace. (There is no formal standard for CSV so different systems will have different ways of handling it. Many CSV processors reject data with extra whitespace as malformed input.)

In the next edition, I will add a warning note about this:

> **Warning!** Do not add extra spaces between the comma-separated values. The regular expression is written to handle generally-accepted valid CSV, not comma-and-space-separated values.

Alternatively, you could change the regular expression to handle comma-and-space-separated values, as shown in the following code:
```cs
[StringSyntax(StringSyntaxAttribute.Regex)]
private const string CommaSeparatorText =
  @"(?:^|,)\s*(?=[^\"]|(\")?)\"?\s*((?(1)(?:[^""]|\\"")*|[^,\"]*))\s*\"?(?=,|$)");
```

> **Warning!** The preceding regular expression was provided by a reader so treat it with caution.

# Page 467 - Good practice with collections

> Thanks to **rene** in the book's Discord channel for suggesting this improvement.

Before this final section in the *Storing multiple objects in collections* topic, I will add a summary table for collection types based on **rene**'s [initial document](../ch08-collections.md)

# Page 488 - Controlling how you work with files

> Thanks to [Vlad Alexandru Meici](https://github.com/vladmeici) who raised an [issue in the 8th edition's GitHub repository on December 31, 2024](https://github.com/markjprice/cs12dotnet8/issues/81) that prompted this improvement.

The `FileShare` enum type is described as:

- `FileShare`: This controls locks on a file to allow other processes the specified level of access, like `Read`.

In the 10th edition, I will improve the grammar of the sentence:

- `FileShare`: This controls locks on a file to allow other processes **to have** the specified level of access, like `Read`.

# Chapter 10 - Working with Data Using Entity Framework Core

> Thanks to [P9avel](https://github.com/P9avel) who raised an [issue in the book's GitHub repository on November 17, 2024](https://github.com/markjprice/cs13net9/issues/1) that prompted this improvement.

This chapter introduces EF Core and how to use it to query and manipulate data in a relational database like SQLite or SQL Server. All code examples are shown in a console app and use synchronous code. This is best for learning EF Core because it keeps the code as simple as possible and focussed on the topic covered, but once a reader needs to implement EF Core in a server-side project like an ASP.NET Core Web API project, it is important to use asynchronous code. 

In the next edition, I will add a new section at the end to highlight how to use tasks and the asynchronous methods to avoid thread exhaustion.

# Page 752 - Creating data repositories with caching for entities

In Step 10, I wrote, "Implement the `Create` method, as shown in the following code:"
```cs
public async Task<Customer?> CreateAsync(Customer c)
{
  c.CustomerId = c.CustomerId.ToUpper(); // Normalize to uppercase.

  // Add to database using EF Core.
  EntityEntry<Customer> added =
    await _db.Customers.AddAsync(c);
  
  int affected = await _db.SaveChangesAsync();
  if (affected == 1)
  {
    // If saved to database then store in cache.
    await _cache.SetAsync(c.CustomerId, c);
    return c;
  }
  return null;
}
```

The return value of the EF Core `DbSet<Customer>.AddAsync` method is an `EntityEntry<Customer>`. The code stores this in a local vaariable named `added` but we do not do anything with it. We could simplify the code by not defining and setting the `added` variable, as shown in the following code:
```cs
public async Task<Customer?> CreateAsync(Customer c)
{
  c.CustomerId = c.CustomerId.ToUpper(); // Normalize to uppercase.

  // Add to database using EF Core.
  await _db.Customers.AddAsync(c);
  
  int affected = await _db.SaveChangesAsync();
  if (affected == 1)
  {
    // If saved to database then store in cache.
    await _cache.SetAsync(c.CustomerId, c);
    return c;
  }
  return null;
}
```

A reason you might want the local variable is to discover database-assigned values like an identifier. But the `Customers` table uses a five-character text value for its primary key column that must be supplied by client code before adding to the database so it's not necessary in this scenario.

But instead of the `Customers` table, if we were adding a new entity to the `Shippers` table which has an auto-incrementing integer primary key column (or any other database-assigned value like a GUID or calculated value), then you could use the local `added` variable to read that assigned value, as shown in the following code:
```cs
public async Task<Shipper?> CreateAsync(Shipper s)
{
  // Add to database using EF Core.
  EntityEntry<Shipper> added = await _db.Shippers.AddAsync(s);

  int affected = await _db.SaveChangesAsync();
  if (affected == 1)
  {
    // If saved to database then store in cache.
    await _cache.SetAsync(s.ShipperId, s);

    // You can also read any database-assigned values.
    int assignedShipperId = added.Entity.ShipperId;

    return s;
  }
  return null;
}

```

In the next edition, I will add some information about this, similar to the preceding explanation. 

> **More Information**: You can learn more at the following link: https://learn.microsoft.com/en-us/ef/core/change-tracking/entity-entries.

# Appendix - Exercise 3.1 – Test your knowledge

> Thanks to **rene**/`rene510` in the Discord channel for asking a question about this.

In Question 2, "What happens when you divide a double variable by 0?", in my suggested answer I wrote, "The `double` type contains a special value of `Infinity`. Instances of floating-point numbers can have the special values of `NaN` (not a number) or, in the case of dividing by `0`, either `PositiveInfinity` or `NegativeInfinity`."

In the next edition, I will add that those special values output as `8` and `-8`.
