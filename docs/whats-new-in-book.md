**What's New in the 9th Edition**

There are hundreds of minor fixes and improvements throughout the 9th edition; too many to list individually. 

All [errata](https://github.com/markjprice/cs12dotnet8/blob/main/docs/errata/errata.md) and [improvements](https://github.com/markjprice/cs12dotnet8/blob/main/docs/errata/improvements.md) for the 8th edition (up to mid-September 2024) have been made to the 9th edition. After publishing the 9th edition, any errata and improvements for the 8th edition have been duplicated in both the 8th and 9th edition [errata and improvements](https://github.com/markjprice/cs13net9/blob/main/docs/errata/README.md).

The main new sections in *C# 13 and .NET 9 - Modern Cross-Platform Development*, 9th edition compared to the 8th edition are shown below.

- [Chapter 1 Hello C#, Welcome .NET!](#chapter-1-hello-c-welcome-net)
- [Chapter 2 Speaking C#](#chapter-2-speaking-c)
- [Chapter 3 Controlling Flow, Converting Types, and Handling Exceptions](#chapter-3-controlling-flow-converting-types-and-handling-exceptions)
- [Chapter 4 Writing, Debugging, and Testing Functions](#chapter-4-writing-debugging-and-testing-functions)
- [Chapter 5 Building Your Own Types with Object-Oriented Programming](#chapter-5-building-your-own-types-with-object-oriented-programming)
- [Chapter 6 Implementing Interfaces and Inheriting Classes](#chapter-6-implementing-interfaces-and-inheriting-classes)
- [Chapter 7 Packaging and Distributing .NET Types](#chapter-7-packaging-and-distributing-net-types)
- [Chapter 8 Working with Common .NET Types](#chapter-8-working-with-common-net-types)
- [Chapter 9 Working with Files, Streams, and Serialization](#chapter-9-working-with-files-streams-and-serialization)
- [Chapter 10 Working with Data Using Entity Framework Core](#chapter-10-working-with-data-using-entity-framework-core)
- [Chapter 11 Querying and Manipulating Data Using LINQ](#chapter-11-querying-and-manipulating-data-using-linq)
- [Chapter 12 Introducing Modern Web Development Using .NET](#chapter-12-introducing-modern-web-development-using-net)
- [Chapter 13 Building Websites Using ASP.NET Core](#chapter-13-building-websites-using-aspnet-core)
- [Chapter 14 Building Interactive Web Components Using Blazor](#chapter-14-building-interactive-web-components-using-blazor)
- [Chapter 15 Building and Consuming Web Services](#chapter-15-building-and-consuming-web-services)

# Chapter 1 Hello C#, Welcome .NET!
- Moved the Polyglot Notebooks section to an optional exercise at the end of this chapter.
- Added a new section, *Getting help on Discord and other chat forums*.
- Added a new section, *Source code in documentation*.

# Chapter 2 Speaking C#
- Added a new section, *Special real number values*.
- Added a new section, *What does new do?*.
- Added a new section, *When does ReadLine return null?*.

# Chapter 3 Controlling Flow, Converting Types, and Handling Exceptions
- Added a new section, *Trailing commas*.
- Added a new section, *Base64 for URLs*, a new .NET 9 feature.

# Chapter 4 Writing, Debugging, and Testing Functions
- Moved the *Logging during development and runtime* section online-only: https://github.com/markjprice/cs13net9/blob/main/docs/ch04-logging.md

# Chapter 5 Building Your Own Types with Object-Oriented Programming
- Added a new section, *Changing an enum base type for performance*.
- Added a new section, *Partial methods*.
- Added a new section, *Partial properties*, a new C# 13 feature.

# Chapter 6 Implementing Interfaces and Inheriting Classes
- Moved the *Managing memory with reference and value types* section online-only: https://github.com/markjprice/cs13net9/blob/main/docs/ch06-memory.md
- Added a new section, *Method chaining or fluent style*.

# Chapter 7 Packaging and Distributing .NET Types
- Added new sections to explain how the project file works, *PropertyGroup element*, *ItemGroup element*, and *Label and Condition attributes*.
- Added a new section, *Package sources*.
- Moved the *Decompiling .NET assemblies* section online-only: https://github.com/markjprice/cs13net9/blob/main/docs/ch07-decompiling.md

# Chapter 8 Working with Common .NET Types
- Added a new section, *Multiplying big integers*, an improved .NET 9 feature.
- Updated the *Generating GUIDs* section with the new .NET 9 support for version 7 of the UUID specification.
- Added a new section, *Working with characters*.
- Added a new section, *Searching in strings*, to explain the improved `SearchValues` type in .NET 9.
- Updated the *Improving regular expression performance with source generators* section to use partial properties instead of partial methods.
- Noted that .NET 9 introduces a `Remove` method for `PriorityQueue`.
- Added a new section, *Using the spread element*.
- Added a new section, *Returning collections from members* to cover those good practices.
- Added a new section, *Using spans for efficient text handling*.

# Chapter 9 Working with Files, Streams, and Serialization
- Added a new section, *JSON schema exporter*, a new .NET 9 feature.
- Added a new section, *A warning about binary serialization using BinaryFormatter*.
- Moved the *Working with environment variables* section online-only: https://github.com/markjprice/cs13net9/blob/main/docs/ch09-environment-variables.md

# Chapter 10 Working with Data Using Entity Framework Core
- Moved the *Loading and tracking patterns with EF Core* section online-only: https://github.com/markjprice/cs13net9/blob/main/docs/ch10-tracking.md
- Moved the *Modifying data with EF Core* section online-only: https://github.com/markjprice/cs13net9/blob/main/docs/ch10-modifying.md

# Chapter 11 Querying and Manipulating Data Using LINQ
- Split the table of LINQ methods into two: deferred and non-deferred, and added the new .NET 9 LINQ methods like `CountBy`.
- Added a new section, *Getting the index as well as items*, a new .NET 9 feature.
- Moved the *Aggregating and paging sequences* section online-only: https://github.com/markjprice/cs13net9/blob/main/docs/ch11-aggregating.md

# Chapter 12 Introducing Modern Web Development Using .NET
- Added guidance for choosing between "modern" and "mature" web development technologies in .NET.
- Added a new section, *Central package management*, and used CPM for the NuGet packages in all the projects for Chapters 12 to 15.

# Chapter 13 Building Websites Using ASP.NET Core
- Added a new section, *Architecture of ASP.NET Core*.
- Added a new section, *Understanding MapStaticAssets*, a new ASP.NET Core 9 feature.
- Replaced Razor Pages with Blazor SSR for the coding tasks in this chapter in the new section, *Exploring Blazor static SSR*.
- Moved the *Configuring services and the HTTP request pipeline* section online-only: https://github.com/markjprice/cs13net9/blob/main/docs/ch13-http-pipeline.md

# Chapter 14 Building Interactive Web Components Using Blazor
- Swapped the order of this chapter with the web services chapter so all the UI stuff comes together.
- Moved the *History of Blazor* and *Understanding Blazor components* sections from this chapter to the previous chapter.

# Chapter 15 Building and Consuming Web Services
- Updated the chapter's web service project to use modern ASP.NET Core Minimal API instead of mature controller-based ASP.NET Core Web API.
- Added a new section, *In-memory, distributed, and hybrid caches*, and updated the data repository to use the new ASP.NET Core 9 hybrid cache.
- Added a new section, *Understanding the OpenAPI Specification*, and explained the removal of Swashbuckle and the use of ASP.NET Core 9's own OpenAPI documentation feature.
- Moved the *Testing requests with the Swagger UI* section online-only: https://github.com/markjprice/cs13net9/blob/main/docs/ch15-swagger-ui.md
