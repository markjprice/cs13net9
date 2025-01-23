**Command-Lines**

To make it easier to enter commands at the prompt, this page lists all commands as a single line that can be copied and pasted.

> Note: Page numbers will be updated once the final print files are made available to me in November 2023.

- [Chapter 1 - Hello, C#! Welcome, .NET!](#chapter-1---hello-c-welcome-net)
  - [Page 12 - Managing VS Code extensions at the command prompt](#page-12---managing-vs-code-extensions-at-the-command-prompt)
  - [Page 16 - Listing and removing versions of .NET](#page-16---listing-and-removing-versions-of-net)
  - [Page 22 - Understanding top-level programs](#page-22---understanding-top-level-programs)
  - [Page 27 - Writing code using VS Code](#page-27---writing-code-using-vs-code)
  - [Page 30 - Compiling and running code using the dotnet CLI](#page-30---compiling-and-running-code-using-the-dotnet-cli)
  - [Page 30 - Adding a second project using VS Code](#page-30---adding-a-second-project-using-vs-code)
  - [Page 36 - Cloning the book solution code repository](#page-36---cloning-the-book-solution-code-repository)
  - [Page 37 - Getting help for the dotnet tool](#page-37---getting-help-for-the-dotnet-tool)
- [Chapter 2 - Speaking C#](#chapter-2---speaking-c)
  - [Page 59 - How to output the SDK version](#page-59---how-to-output-the-sdk-version)
  - [Page 104 - Exploring more about console apps](#page-104---exploring-more-about-console-apps)
  - [Page 118 - Passing arguments to a console app](#page-118---passing-arguments-to-a-console-app)
- [Chapter 4 - Writing, Debugging, and Testing Functions](#chapter-4---writing-debugging-and-testing-functions)
  - [Page 213 - Hot reloading using VS Code and dotnet watch](#page-213---hot-reloading-using-vs-code-and-dotnet-watch)
  - [Page 216 - Creating a class library that needs testing](#page-216---creating-a-class-library-that-needs-testing)
- [Chapter 7 - Packaging and Distributing .NET Types](#chapter-7---packaging-and-distributing-net-types)
  - [Page 371 - Checking your .NET SDKs for updates](#page-371---checking-your-net-sdks-for-updates)
  - [Page 383 - Creating a .NET Standard 2.0 class library](#page-383---creating-a-net-standard-20-class-library)
- [Page 384 - Controlling the .NET SDK](#page-384---controlling-the-net-sdk)
  - [Page 389 - Understanding dotnet commands](#page-389---understanding-dotnet-commands)
  - [Page 389 - Getting information about .NET and its environment](#page-389---getting-information-about-net-and-its-environment)
  - [Page 391 - Publishing a self-contained app](#page-391---publishing-a-self-contained-app)
  - [Page 393 - Publishing a single-file app](#page-393---publishing-a-single-file-app)
  - [Page 394 - Enabling assembly-level trimming](#page-394---enabling-assembly-level-trimming)
  - [Page 395 - Enabling type-level and member-level trimming](#page-395---enabling-type-level-and-member-level-trimming)
  - [Page 395 - Controlling where build artifacts are created](#page-395---controlling-where-build-artifacts-are-created)
  - [Page 400 - Publishing a native AOT project](#page-400---publishing-a-native-aot-project)
- [Chapter 10 - Working with Data Using Entity Framework Core](#chapter-10---working-with-data-using-entity-framework-core)
  - [Page 533 - Setting up SQLite for macOS and Linux](#page-533---setting-up-sqlite-for-macos-and-linux)
  - [Page 533 - Creating the Northwind sample database for SQLite](#page-533---creating-the-northwind-sample-database-for-sqlite)
  - [Page 549 - Setting up the dotnet-ef tool](#page-549---setting-up-the-dotnet-ef-tool)
  - [Page 552 - Scaffolding models using an existing database](#page-552---scaffolding-models-using-an-existing-database)
- [Chapter 11 - Querying and Manipulating Data Using LINQ](#chapter-11---querying-and-manipulating-data-using-linq)
  - [Page 599 - Creating a console app for exploring LINQ to Entities](#page-599---creating-a-console-app-for-exploring-linq-to-entities)
- [Chapter 12 - Introducing Modern Web Development Using ASP.NET Core](#chapter-12---introducing-modern-web-development-using-aspnet-core)
  - [Page 634 - Creating a class library for entity models using SQLite](#page-634---creating-a-class-library-for-entity-models-using-sqlite)
- [Chapter 13 - Building Websites Using ASP.NET Core](#chapter-13---building-websites-using-aspnet-core)
  - [Page 660 - Creating an empty ASP.NET Core project](#page-660---creating-an-empty-aspnet-core-project)
  - [Page 665 - Testing and securing the website](#page-665---testing-and-securing-the-website)
- [Chapter 14 - Interactive Web Components Using Blazor](#chapter-14---interactive-web-components-using-blazor)
  - [Page 698 - Creating a Blazor Web App project](#page-698---creating-a-blazor-web-app-project)
- [Chapter 15 - Building and Consuming Web Services](#chapter-15---building-and-consuming-web-services)
  - [Page 738 - Creating an ASP.NET Core Minimal API project](#page-738---creating-an-aspnet-core-minimal-api-project)

# Chapter 1 - Hello, C#! Welcome, .NET!

## Page 12 - Managing VS Code extensions at the command prompt

```shell
code --install-extension ms-dotnettools.csdevkit
```

## Page 16 - Listing and removing versions of .NET

Listing all installed .NET SDKS:
```shell
dotnet --list-sdks
```

Listing all installed .NET runtimes:
```shell
dotnet --list-runtimes
```

Details of all .NET installations:
```shell
dotnet --info
```

## Page 22 - Understanding top-level programs

If you are using the dotnet CLI at the command prompt, add a switch to generate a console app project using the legacy `Program` class with a `Main` method:
```shell
dotnet new console --use-program-main
```

## Page 27 - Writing code using VS Code

Using the dotnet CLI to create a new solution named `Chapter01`:
```shell
dotnet new sln --name Chapter01
```

Creating a new **Console App** project in a folder named `HelloCS` with a project file named `HelloCS.csproj`:
```shell
dotnet new console --output HelloCS
```

Adding a named project to the solution file:
```shell
dotnet sln add HelloCS
```

Opening VS Code in the current folder:
```shell
code .
```

Creating a new **Console App** project named `HelloCS` that targets a specified framework version, for example, .NET 8:
```shell
dotnet new console -f net8.0 -o HelloCS
```

## Page 30 - Compiling and running code using the dotnet CLI
```shell
dotnet run
```

## Page 30 - Adding a second project using VS Code

Creating a project named `AboutMyEnvironment` using the legacy `Program` class with a `Main` method:
```shell
dotnet new console -o AboutMyEnvironment --use-program-main
```

Add the project to the solution:
```shell
dotnet sln add AboutMyEnvironment
```

## Page 36 - Cloning the book solution code repository

```shell
git clone https://github.com/markjprice/cs13net9.git
```

## Page 37 - Getting help for the dotnet tool

Getting help for a `dotnet` command like `build` from the documentation web page:
```shell
dotnet help build
```

Getting help for a `dotnet` command like `build` at the command prompt:
```shell
dotnet build -?
```

Getting help for a specified project template, for example, `console`:
```shell
dotnet new console -?
```

# Chapter 2 - Speaking C#

## Page 59 - How to output the SDK version

Output the current version of the .NET SDK:
```shell
dotnet --version
```

## Page 104 - Exploring more about console apps

Example of a command line with multiple arguments:
```shell
dotnet new console -lang "F#" --name "ExploringConsole"
```

## Page 118 - Passing arguments to a console app

Passing four arguments when running your project:
```shell
dotnet run firstarg second-arg third:arg "fourth arg"
```

Setting options using arguments:
```shell
dotnet run red yellow 50
```

# Chapter 4 - Writing, Debugging, and Testing Functions

## Page 213 - Hot reloading using VS Code and dotnet watch

Starting a project using Hot Reload:
```shell
dotnet watch
```

## Page 216 - Creating a class library that needs testing

Creating a class library project and adding it to the solution file:
```shell
dotnet new classlib -o CalculatorLib
```
```shell
dotnet sln add CalculatorLib
```

Creating an XUnit text project and adding it to the solution file:
```shell
dotnet new xunit -o CalculatorLibUnitTests
```
```shell
dotnet sln add CalculatorLibUnitTests
```

Running a unit test project:
```shell
dotnet test
```

# Chapter 7 - Packaging and Distributing .NET Types

## Page 371 - Checking your .NET SDKs for updates

Listing the installed .NET SDKs with a column to indicate if it has a newer version that can be upgraded to:
```shell
dotnet sdk check
```

## Page 383 - Creating a .NET Standard 2.0 class library

Creating a new class library project that targets .NET Standard 2.0:
```shell
dotnet new classlib -f netstandard2.0
```

# Page 384 - Controlling the .NET SDK

Listing the installed .NET SDKs:
```shell
dotnet --list-sdks
```

Creating a `global.json` file to control to default .NET SDK for projects created in the current folder and its descendents:
```shell
dotnet new globaljson --sdk-version 8.0.400
```

## Page 389 - Understanding dotnet commands

Listing available project templates using .NET 7 or later:
```shell
dotnet new list
```

Listing available project templates using .NET 6 or earlier:
```shell
dotnet new --list
```

Listing available project templates using .NET 6 or earlier (short form):
```shell
dotnet new -l
```

## Page 389 - Getting information about .NET and its environment

Getting detailed information about installed .NET runtimes, SDKs, and workloads:
```shell
dotnet --info
```

## Page 391 - Publishing a self-contained app

Build and publish the release version for Windows:
```shell
dotnet publish -c Release -r win-x64 --self-contained
```

Build and publish the release version for Windows on ARM64:
```shell
dotnet publish -c Release -r win-arm64 --self-contained
```

Build and publish the release version for macOS on Apple Silicon:
```shell
dotnet publish -c Release -r osx-arm64 --self-contained
```

Build and publish the release version for Linux on Intel:
```shell
dotnet publish -c Release -r linux-x64 --self-contained
```

## Page 393 - Publishing a single-file app

```shell
dotnet publish -c Release -r win-x64 --no-self-contained -p:PublishSingleFile=true
```

```shell
dotnet publish -c Release -r win-x64 --self-contained -p:PublishSingleFile=true
```

## Page 394 - Enabling assembly-level trimming

```shell
dotnet publish -c Release -r win-x64 --self-contained -p:PublishSingleFile=true -p:PublishTrimmed=True
```

## Page 395 - Enabling type-level and member-level trimming

```shell
dotnet publish -c Release -r win-x64 --self-contained -p:PublishSingleFile=true -p:PublishTrimmed=True -p:TrimMode=Link
```

## Page 395 - Controlling where build artifacts are created

To create a MSBuild `Directory.Build.props` file:
```shell
dotnet new buildprops --use-artifacts
```

## Page 400 - Publishing a native AOT project

```shell
dotnet publish
```

# Chapter 10 - Working with Data Using Entity Framework Core

## Page 533 - Setting up SQLite for macOS and Linux

On Linux, you can get set up with SQLite using the following command:
```shell
sudo apt-get install sqlite3
```

## Page 533 - Creating the Northwind sample database for SQLite

Creating the Northwind SQLite database:
```shell
sqlite3 Northwind.db -init Northwind4SQLite.sql
```

## Page 549 - Setting up the dotnet-ef tool

Listing installed `dotnet` global tools:
```shell
dotnet tool list --global
```

Updating an older `dotnet-ef` tool:
```shell
dotnet tool update --global dotnet-ef
```

Installing the latest `dotnet-ef` as a global tool:
```shell
dotnet tool install --global dotnet-ef
```

Updating to a specific version of `dotnet-ef` tool:
```shell
dotnet tool update --global dotnet-ef --version 9.0-*
```

Uninstalling an older `dotnet-ef` tool:
```shell
dotnet tool uninstall --global dotnet-ef
```

## Page 552 - Scaffolding models using an existing database

```shell
dotnet ef dbcontext scaffold "Data Source=Northwind.db" Microsoft.EntityFrameworkCore.Sqlite --table Categories --table Products --output-dir AutoGenModels --namespace WorkingWithEFCore.AutoGen --data-annotations --context NorthwindDb
```

Note the following:
- The command action: `dbcontext scaffold`
- The connection string: `"Data Source=Northwind.db"`
- The database provider: `Microsoft.EntityFrameworkCore.Sqlite`
- The tables to generate models for: `--table Categories --table Products`
- The output folder: `--output-dir AutoGenModels`
- The namespace: `--namespace WorkingWithEFCore.AutoGen`
- To use data annotations as well as the Fluent API: `--data-annotations`
- To rename the context from [database_name]Context: `--context NorthwindDb`

# Chapter 11 - Querying and Manipulating Data Using LINQ

## Page 599 - Creating a console app for exploring LINQ to Entities

Creating the Northwind SQLite database:
```shell
sqlite3 Northwind.db -init Northwind4Sqlite.sql
```

# Chapter 12 - Introducing Modern Web Development Using ASP.NET Core

## Page 634 - Creating a class library for entity models using SQLite

Creating the Northwind SQLite database:
```shell
sqlite3 Northwind.db -init Northwind4SQLite.sql
```

Creating the EF Core model for the Northwind database:
```shell
dotnet ef dbcontext scaffold "Data Source=../Northwind.db" Microsoft.EntityFrameworkCore.Sqlite --namespace Northwind.EntityModels --data-annotations
```

# Chapter 13 - Building Websites Using ASP.NET Core

## Page 660 - Creating an empty ASP.NET Core project

To create a new empty ASP.NET Core project:
```shell
dotnet new web
```

## Page 665 - Testing and securing the website

Starting an ASP.NET Core project and specifying the `https` profile:
```shell
dotnet run --launch-profile https
```

# Chapter 14 - Interactive Web Components Using Blazor

## Page 698 - Creating a Blazor Web App project

Creating a new project using the **Blazor Web App** template with server-side or client-side interactivity enabled:
```shell
dotnet new blazor --interactivity Auto -o Northwind.Blazor
```
# Chapter 15 - Building and Consuming Web Services

## Page 738 - Creating an ASP.NET Core Minimal API project

Creating a Web API project using ASP.NET Core Minimal API:
```shell
dotnet new webapi -o Northwind.WebApi
```

Creating a Web API project using Minimal API (explicitly):
```shell
dotnet new webapi --use-minimal-api -o Northwind.WebApi
```

Creating a Web API project using Minimal APIs (explicitly, short form):
```shell
dotnet new webapi -minimal -o Northwind.WebApi
```

Creating a Web API project using controllers:
```shell
dotnet new webapi --use-controllers -o Northwind.WebApi
```

Creating a Web API project using controllers (short form):
```shell
dotnet new webapi -controllers -o Northwind.WebApi
```

