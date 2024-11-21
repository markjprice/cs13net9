**Errata** (2 items)

If you find any mistakes, then please [raise an issue in this repository](https://github.com/markjprice/cs13net9/issues) or email me at markjprice (at) gmail.com.

- [Page 29 - Writing code using VS Code](#page-29---writing-code-using-vs-code)
- [Exercise 13.2 – practice exercises - Build web pages for functions](#exercise-132--practice-exercises---build-web-pages-for-functions)


# Page 29 - Writing code using VS Code

> Thanks to **Andriko** in the book's Discord channel for asking a question about this issue.

I wrote, "VS Code has an improved project creation experience that provides you access to the same options you can use when creating a new project through the `dotnet` CLI. To enable this ability, you must change a setting, as shown in the following configuration:"
```
"csharp.experimental.dotnetNewIntegration": true
```

This feature is no longer in preview so you do not need to enable it. In the next edition, I will remove the sentence about enabling it and the setting.

# Exercise 13.2 – practice exercises - Build web pages for functions

This exercise should have been in *Chapter 14 Building Interactive Web Components Using Blazor*, because it is much easier to implement using interactive Blazor features rather than the limited Blazor static server-side rendering (SSR).

Updated functions page to use server-side interactivity:
https://github.com/markjprice/cs13net9/blob/main/code/ModernWeb/Northwind.Blazor/Northwind.Blazor/Components/Pages/Functions.razor

Updated navmenu to include link to functions page:
https://github.com/markjprice/cs13net9/blob/main/code/ModernWeb/Northwind.Blazor/Northwind.Blazor/Components/Layout/NavMenu.razor
