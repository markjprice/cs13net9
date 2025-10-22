**Ninth Edition's support for .NET 10**

- [.NET 10 downloads and announcements](#net-10-downloads-and-announcements)
- [How to switch from .NET 9 to .NET 10](#how-to-switch-from-net-9-to-net-10)
  - [Upgrading the target framework for a project](#upgrading-the-target-framework-for-a-project)
  - [Upgrading packages for a project](#upgrading-packages-for-a-project)
- [What's New in .NET 10 and where will I cover those new features?](#whats-new-in-net-10-and-where-will-i-cover-those-new-features)
- [.NET 11 and .NET 12 downloads and announcements](#net-11-and-net-12-downloads-and-announcements)

# .NET 10 downloads and announcements

Microsoft will release previews of .NET 10 regularly starting in February 2025 until the general availability (GA) version on Tuesday, November 11, 2025.

- [Download .NET 10.0 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- [.NET 10 Release Index - Previews 1 to 7, Release Candidates 1 and 2](https://github.com/dotnet/core/discussions/9764)

# How to switch from .NET 9 to .NET 10

After [downloading](https://dotnet.microsoft.com/download/dotnet/10.0) and installing .NET 10.0 SDK, follow the step-by-step instructions in the book and they should work as expected since the project file will automatically reference .NET 10.0 as the target framework. 

## Upgrading the target framework for a project

To upgrade a project in the GitHub repository from .NET 9.0 to .NET 10.0 often only requires a target framework change in your project file.

Change this:

```xml
<TargetFramework>net9.0</TargetFramework>
```

To this:

```xml
<TargetFramework>net10.0</TargetFramework>
```

> **Warning!** Sometimes it is better to recreate a project because the project template and APIs may have changed and only changing the target framework is not enough. This is especially true for third-party project templates like Umbraco CMS.

## Upgrading packages for a project

For projects that reference additional NuGet packages, use the latest NuGet package version instead of the version given in the book. For example, you might reference a package, as shown in the following markup:
```xml
<ItemGroup>
  <PackageReference
    Include="Microsoft.Extensions.Configuration.Binder"
    Version="9.0.0" />
</ItemGroup>
```

To use .NET 10 Preview 1 packages, search https://www.nuget.org for the package and find its latest preview version number. For example, for [Preview 1](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.Binder/10.0.0-preview.1.25080.5), as shown in the following markup:
```xml
<ItemGroup>
  <PackageReference
    Include="Microsoft.Extensions.Configuration.Binder"
    Version="10.0.0-preview.1.25080.5" />
</ItemGroup>
```

To always use latest .NET 10 preview, release candidate, or patch version package, use a version number wildcard, as shown in the following markup:
```xml
<ItemGroup>
  <PackageReference
    Include="Microsoft.Extensions.Configuration.Binder"
    Version="10.0-*" />
</ItemGroup>
```

> You can search for the correct NuGet package version numbers yourself at the following link: https://www.nuget.org/packages/Microsoft.Extensions.Configuration.Binder#versions-body-tab.

# What's New in .NET 10 and where will I cover those new features?

Official page: https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-10/overview

Preview updates: https://github.com/dotnet/core/discussions

# .NET 11 and .NET 12 downloads and announcements

Microsoft will release previews of .NET 11 regularly starting in February 2026 until the final version on Tuesday, November 10, 2026.

- [Download .NET 11.0 SDK](https://dotnet.microsoft.com/download/dotnet/11.0). **Warning!** This link will not activate until February 2026.
- [Download .NET 12.0 SDK](https://dotnet.microsoft.com/download/dotnet/12.0). **Warning!** This link will not activate until February 2027.
