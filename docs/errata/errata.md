**Errata** (30 items)

If you find any mistakes, then please [raise an issue in this repository](https://github.com/markjprice/cs13net9/issues) or email me at markjprice (at) gmail.com.

- [Page 24 - Revealing the namespace for the Program class](#page-24---revealing-the-namespace-for-the-program-class)
- [Page 29 - Writing code using VS Code](#page-29---writing-code-using-vs-code)
- [Page 91 - Comparing double and decimal types](#page-91---comparing-double-and-decimal-types)
- [Page 106 - Rider and its warnings about boxing](#page-106---rider-and-its-warnings-about-boxing)
- [Page 112 - Custom number formatting](#page-112---custom-number-formatting)
- [Page 147 - Understanding how foreach works internally](#page-147---understanding-how-foreach-works-internally)
- [Page 175 - Throwing overflow exceptions with the checked statement](#page-175---throwing-overflow-exceptions-with-the-checked-statement)
- [Page 179 - Test your knowledge of operators](#page-179---test-your-knowledge-of-operators)
- [Page 208 - Using the Visual Studio Code integrated terminal during debugging](#page-208---using-the-visual-studio-code-integrated-terminal-during-debugging)
- [Page 298 - Defining a primary constructor for a class](#page-298---defining-a-primary-constructor-for-a-class)
- [Page 383 - Creating a .NET Standard class library](#page-383---creating-a-net-standard-class-library)
- [Page 392 - Publishing a self-contained app](#page-392---publishing-a-self-contained-app)
- [Page 392 - Publishing a self-contained app](#page-392---publishing-a-self-contained-app-1)
- [Page 393 - Publishing a single-file app](#page-393---publishing-a-single-file-app)
- [Page 400 - Publishing a native AOT project](#page-400---publishing-a-native-aot-project)
- [Page 437 - Understanding the syntax of a regular expression](#page-437---understanding-the-syntax-of-a-regular-expression)
- [Page 444 - Improving regular expression performance with source generators](#page-444---improving-regular-expression-performance-with-source-generators)
- [Page 446 - Storing multiple objects in collections](#page-446---storing-multiple-objects-in-collections)
- [Page 461 - Read-only, immutable, and frozen collections](#page-461---read-only-immutable-and-frozen-collections)
- [Page 483 - Managing directories, Managing files](#page-483---managing-directories-managing-files)
- [Page 570 - Getting a single entity](#page-570---getting-a-single-entity)
- [Page 650 - Testing the class libraries, Page 693 - Build a data-driven web page, Page 694 - Build web pages for functions](#page-650---testing-the-class-libraries-page-693---build-a-data-driven-web-page-page-694---build-web-pages-for-functions)
- [Page 660 - Creating an empty ASP.NET Core project, Page 701 - Creating an ASP.NET Core Web API project](#page-660---creating-an-empty-aspnet-core-project-page-701---creating-an-aspnet-core-web-api-project)
- [Page 683 - Adding code to a Blazor static SSR page](#page-683---adding-code-to-a-blazor-static-ssr-page)
- [Page 750 - Creating data repositories with caching for entities](#page-750---creating-data-repositories-with-caching-for-entities)
- [Page 756 - Configuring the customer repository](#page-756---configuring-the-customer-repository)
- [Page 780 - Companion books to continue your learning journey](#page-780---companion-books-to-continue-your-learning-journey)
- [Exercise 13.2 – practice exercises - Build web pages for functions](#exercise-132--practice-exercises---build-web-pages-for-functions)
- [Appendix - Page 3](#appendix---page-3)
- [Appendix - Page 5](#appendix---page-5)

# Page 24 - Revealing the namespace for the Program class

> Thanks to **John Tempest** in an email for raising this issue on December 21, 2024.

In the **Good Practice** box, I wrote, "Code editors have a feature named code snippets. These allow you to insert pieces of code that you commonly use, by typing a shortcut and pressing *Tab* twice." But you only need to press *Tab* once.

# Page 29 - Writing code using VS Code

> Thanks to **Andriko** in the book's Discord channel for asking a question about this issue.

I wrote, "In the preceding steps, I showed you how to use the dotnet CLI to create solutions and projects. Finally, with the August 2024 or later releases of the C# Dev Kit, VS Code has an improved project creation experience that provides you access to the same options you can use when creating a new project through the `dotnet` CLI. To enable this ability, you must change a setting, as shown in the following configuration:"
```
"csharp.experimental.dotnetNewIntegration": true
```

This feature is no longer in preview so you do not need to enable it. In the next edition, I will remove the sentence about enabling it and the setting.

# Page 91 - Comparing double and decimal types

> Thanks to [Anass Sabiri](https://github.com/lambdacore12) for raising [this issue on February 19, 2025](https://github.com/markjprice/cs13net9/issues/24).

In the **Good Practice** box, the first link has moved to https://www-users.cse.umn.edu/~arnold/disasters/patriot.html.

# Page 106 - Rider and its warnings about boxing

> Thanks to [Anass Sabiri](https://github.com/lambdacore12) for raising [this issue on February 20, 2025](https://github.com/markjprice/cs13net9/issues/25).

The link for best practices has moved to this link: https://docs.unity3d.com/Manual/performance-reference-types.html, and you need to scroll down to one of the last sections, titled *Avoid converting value types to reference types*.

# Page 112 - Custom number formatting

> Thanks to [Donald Maisey](https://github.com/donaldmaisey) for raising [this issue on February 5, 2025](https://github.com/markjprice/cs13net9/issues/13).

In Step 1, I tell the reader to enter some code that calls the `WriteLine` method without the `Console.` prefix. I do not introduce simplifying the statement like that for another two pages. In the next edition, I will add the prefix, as shown in the following code:
```cs
decimal value = 0.325M;
Console.WriteLine("Currency: {0:C}, Percentage: {0:0.0%}", value);
```

# Page 147 - Understanding how foreach works internally

> Thanks to [Justin Treher](https://github.com/jtreher) for raising [this issue on January 3, 2025](https://github.com/markjprice/cs13net9/issues/6).

In Step 1, I wrote, "Type statements to create an array of string variables and then output the length of each one, as shown in the following code:"
```cs
string[] names = { "Adam", "Barry", "Charlie" };

foreach (string name in names)
{
  WriteLine($"{name} has {name.Length} characters.");
}
```

I then wrote, "The compiler turns the `foreach` statement in the preceding example into something like the following pseudocode:"
```cs
IEnumerator e = names.GetEnumerator();

while (e.MoveNext())
{
  string name = (string)e.Current; // Current is read-only!
  WriteLine($"{name} has {name.Length} characters.");
}
```

But the `names` variable is an array, and although arrays implement the `IEnumerable<T>` interface as described in this section, the compiler is smart enough to ignore that and instead write a `for` loop that uses the `Length` property of the array since that is more efficient than using the `IEnumerable` interface. 

In the next edition, I will use a `List<string>` instead of an array for the `names` variable, and add a note that arrays are treated as a special case by the compiler. 

# Page 175 - Throwing overflow exceptions with the checked statement

> Thanks to [Justin Treher](https://github.com/jtreher) for raising [this issue on January 3, 2025](https://github.com/markjprice/cs13net9/issues/7).

In Step 3, I wrote, "let’s get the compiler to warn us about the overflow by wrapping the statements using a `checked` statement block", but it is not the compiler that warns us, it is the runtime that detects the overflow and throws the exception. In the next edition I will replace "compiler" with "runtime".

# Page 179 - Test your knowledge of operators

> Thanks to [Donald Maisey](https://github.com/donaldmaisey) for raising [this issue on February 15, 2025](https://github.com/markjprice/cs13net9/issues/17).

For the name of the exercise project I wrote `Ch03Ex03Operators` when I should have written `Exercise_Operators`.

# Page 208 - Using the Visual Studio Code integrated terminal during debugging

> Thanks to **kingace9371** for asking a question about this, and to **rene** for providing the answer in the book's Discord channel.

In Step 7, I wrote, "In the `launch.json` file editor, click the **Add Configuration...** button, and then select **.NET: Launch .NET Core Console App**"

The name of this option is now called **.NET: Launch Executable file (Console)**, as shown in the following figure:

![.NET: Launch Executable file (Console)](errata-p196.png)

# Page 298 - Defining a primary constructor for a class

> Thanks to [P9avel](https://github.com/P9avel) for raising [this issue on February 16, 2025](https://github.com/markjprice/cs13net9/issues/19).

In Step 6, I wrote, "In `Headset.cs`, add a default parameterless constructor, as highlighted in the following code:"
```cs
namespace Packt.Shared;

public class Headset(string manufacturer, string productName)
{
  public string Manufacturer { get; set; } = manufacturer;
  public string ProductName { get; set; } = productName;
  
  // Default parameterless constructor calls the primary constructor.
  public Headset() : this("Microsoft", "HoloLens") { }
}
```

But the note box underneath the code says, "Note the use of `this()` to call the constructor of the base class and pass two parameters to it when the default constructor of `Headset` is called." The note box should say, "Note the use of `this()` to call the primary constructor and pass two parameters to it when the default constructor of `Headset` is called."

# Page 383 - Creating a .NET Standard class library

> Thanks to [P9avel](https://github.com/P9avel) for raising [this issue on February 18, 2025](https://github.com/markjprice/cs13net9/issues/21).

In the **Good Practice** box, the final version number was written as `0`. It should be `9.0`.

# Page 392 - Publishing a self-contained app

> Thanks to [P9avel](https://github.com/P9avel) for raising [this issue on February 18, 2025](https://github.com/markjprice/cs13net9/issues/22).

In Step 5, I wrote, "note the output folders for the five OSes." There were five folders in earlier editions but in the 9th edition I reduced this. In the next edition, I will remove the word "five".

# Page 392 - Publishing a self-contained app

> Thanks to [P9avel](https://github.com/P9avel) for raising [this issue on February 18, 2025](https://github.com/markjprice/cs13net9/issues/23).

In Step 7, *Figure 7.3*, the screenshot shows `net8.0` in the address bar. It should be `net9.0`.

# Page 393 - Publishing a single-file app

> Thanks to [Vlad Alexandru Meici](https://github.com/vladmeici) for raising [this issue on December 8, 2024](https://github.com/markjprice/cs12dotnet8/issues/77).

In the two command lines, I used `/p` to set a project property when I should have used `-p`. The complete command is:
```
dotnet publish -r win10-x64 -c Release --no-self-contained -p:PublishSingleFile=true
```

# Page 400 - Publishing a native AOT project

> Thanks to [Nathan Wolfe](https://github.com/scotswolfie) for raising [this issue on January 14, 2025](https://github.com/markjprice/cs12dotnet8/issues/83).

I wrote, "A console app that functions correctly during development when the code is untrimmed and JIT-compiled could still fail once you publish it using native AOT because then the code is trimmed and JIT-compiled and, therefore, it is a different code with different behavior."

But I mistakenly repeated "JIT-compiled" when I meant "AOT-compiled". 

I should have written, "A console app that functions correctly during development when the code is untrimmed and JIT-compiled could still fail once you publish it using native AOT because then the code is trimmed and AOT-compiled and, therefore, it is a different code with different behavior."

# Page 437 - Understanding the syntax of a regular expression

> Thanks to **rene** in the book's Discord channel for raising this issue.

In *Table 8.7*, the entry for `{,3}` is wrong. That is not a valid range and so it actually matches the exact string `{,3}`! To match "Up to three", you should use `{0,3}` or `{1,3}` depending on whether you want to accept zero or one as the lowest value. I will fix this in the 10th edition.

# Page 444 - Improving regular expression performance with source generators

> Thanks to [P9avel](https://github.com/P9avel) for raising [this issue on February 21, 2025](https://github.com/markjprice/cs13net9/issues/27).

In Steps 2, 3, and 4, I wrote "`partial` method", when I should have written "`partial` property".

# Page 446 - Storing multiple objects in collections

> Thanks to [P9avel](https://github.com/P9avel) for raising [this issue on February 21, 2025](https://github.com/markjprice/cs13net9/issues/28).

In *Table 8.9*, I wrote `Dictionary<T>`. This should be `Dictionary<TKey, TValue>`. I will also change the order to put it last in the list of collection examples for that row, and add a sentence to the description to explain, "Dictionaries need two types to be specified: one for the key and one for the value."

# Page 461 - Read-only, immutable, and frozen collections

> Thanks to [P9avel](https://github.com/P9avel) for raising [this issue on February 22, 2025](https://github.com/markjprice/cs13net9/issues/30).

I wrote, "Although the `ReadOnlyCollection<T>` has to have an `Add` and a `Remove` method because it implements `ICollection<T>`, it throws a `NotImplementedException` to prevent changes." But it actually throws a `NotSupportedException`.

# Page 483 - Managing directories, Managing files

> Thanks to [Vlad Alexandru Meici](https://github.com/vladmeici) for raising [this issue on December 31, 2024](https://github.com/markjprice/cs12dotnet8/issues/80).

After prompting the user to press any key to delete the directory or file, the code should have an extra statement to output a new line otherwise the next text written to the console will appear immediately at the end of the "Press any key..." text.

This has been fixed in the code solutions here:
https://github.com/markjprice/cs13net9/commit/d75644ad74bf3ffbd9ff202e0bf6f2ad665ca5ea

# Page 570 - Getting a single entity

> Thanks to [es-moises](https://github.com/es-moises) for raising [this issue on January 22, 2025](https://github.com/markjprice/cs12dotnet8/issues/84).

In Step 3, the output in two places shows part of the `WHERE` clause as `"p"."ProductId" > @__id_0` but both should be `"p"."ProductId" = @__id_0`.

# Page 650 - Testing the class libraries, Page 693 - Build a data-driven web page, Page 694 - Build web pages for functions

I end the **Testing the class libraries** section by writing, "Finally, in this chapter, let’s review some key concepts about web development, enabling us to be better prepared to dive into ASP.NET Core Razor Pages in the next chapter."

In the **Build a data-driven web page** exercise, I wrote, "Add a Razor Page to the `Northwind.Web` website..."

In the **Build web pages for functions** exercise, I wrote, "Reimplement some of the console apps from earlier chapters as Razor Pages;"

In these instances, "Razor Pages" or "Razor Page" should be "Blazor" or "Blazor page component".

# Page 660 - Creating an empty ASP.NET Core project, Page 701 - Creating an ASP.NET Core Web API project

> Thanks to **rene** in the Discord channel for this book for raising this issue on February 6, 2025.

In Step 1, I describe the options when creating a new ASP.NET Core project. The option that used to be labelled **Enable Docker** is now labelled **Enable container support**. And the new option labelled **Enlist in .NET Aspire orchestration** should be cleared.

# Page 683 - Adding code to a Blazor static SSR page

> Thanks to [Taylor Fore](https://github.com/trfore) for raising [this issue on January 8, 2025](https://github.com/markjprice/cs13net9/issues/8).

In Step 1, I wrote, `Index.cshtml` when I should have written `Index.razor`.

# Page 750 - Creating data repositories with caching for entities

> Thanks to Jeroen for asking a question about this issue.

In Step 3, I wrote, "In `Program.cs`, before the call to `Build`, in the section for configuring services, register the hybrid cache service..."

Unfortunately, even after the release of .NET 9 on November 12, 2024, the `Microsoft.Extensions.Caching.Hybrid` package is still in preview, and the `AddHybridCache` method call causes a compiler warning. Until the package is released as GA, you will need to surround the call with a temporary warning suppression, as shown in the following code:
```cs
#pragma warning disable EXTEXP0018 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
builder.Services.AddHybridCache(options =>
{
  options.DefaultEntryOptions = new HybridCacheEntryOptions
  {
    Expiration = TimeSpan.FromSeconds(60),
    LocalCacheExpiration = TimeSpan.FromSeconds(30)
  };
});
#pragma warning restore EXTEXP0018 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
```

# Page 756 - Configuring the customer repository

> Thanks to [Andrea](https://github.com/Doriasamp) for raising [this issue on February 12, 2025](https://github.com/markjprice/cs13net9/issues/15).

In Step 7, the statement that returns a `204 No content` response mistakenly included the `new` keyword, as shown in the following code:
```cs
return new TypedResults.NoContent(); // 204 No content.
```

That statement should be:
```cs
return TypedResults.NoContent(); // 204 No content.
```

It was already correct in the code solution repo:
https://github.com/markjprice/cs13net9/blob/main/code/ModernWeb/Northwind.WebApi/Program.Customers.cs#L79

# Page 780 - Companion books to continue your learning journey

> Thanks to [Jort Rodenburg](https://github.com/jjrodenburg) for raising [this issue on January 31, 2025](https://github.com/markjprice/cs13net9/issues/12).

The order of the four books in *Figure 16.1* does not match the order of the numbered descriptions. Numbers 3. and 4. should be swapped.

# Exercise 13.2 – practice exercises - Build web pages for functions

This exercise should have been in *Chapter 14 Building Interactive Web Components Using Blazor*, because it is much easier to implement using interactive Blazor features rather than the limited Blazor static server-side rendering (SSR).

Updated functions page to use server-side interactivity:
https://github.com/markjprice/cs13net9/blob/main/code/ModernWeb/Northwind.Blazor/Northwind.Blazor/Components/Pages/Functions.razor

Updated navmenu to include link to functions page:
https://github.com/markjprice/cs13net9/blob/main/code/ModernWeb/Northwind.Blazor/Northwind.Blazor/Components/Layout/NavMenu.razor

# Appendix - Page 3

> Thanks to [Donald Maisey](https://github.com/donaldmaisey) for raising [this issue on February 5, 2025](https://github.com/markjprice/cs13net9/issues/14).

I re-arranged the practices and exercises at the end of Chapter 2 but forgot to also update the order in the appendix:
- **Exercise 2.1 – Test your knowledge** should be **Exercise 2.3 – Test your knowledge**.
- **Exercise 2.2 – Test your knowledge of number types** is a second part to **Exercise 2.3**.
- **Exercise 2.3 – Practice number sizes and ranges** should be **Exercise 2.2**.

# Appendix - Page 5

> Thanks to [Donald Maisey](https://github.com/donaldmaisey) for raising [this issue on February 15, 2025](https://github.com/markjprice/cs13net9/issues/17).

I re-arranged the practices and exercises at the end of Chapter 2 but forgot to also update the order in the appendix:
- **Exercise 3.1 – Test your knowledge** should be **Exercise 3.3 – Test your knowledge**.
- **Exercise 3.2 – Explore loops and overflow** should be **Exercise 3.2 - Practice exercises** with sub-sections **Loops and overflow**, **Practice loops and operators**, and **Practice exception handling**.
- **Exercise 3.3 – Test your knowledge of operators** should be a subsection of **Exercise 3.3 – Test your knowledge**.

It looks like I forgot to update all chapters in the appendix but it should be obvious enough for readers to understand. I will fix them all in the next edition. 
