**Understanding async and await**

C# 5 introduced two C# keywords when working with the `Task` type that enable easy multithreading. The pair of keywords is especially useful for the following:
- Implementing multitasking for a graphical user interface (GUI).
- Improving the scalability of web applications and web services.
- Preventing blocking calls when interacting with the filesystem, databases, and remote services, all of which tend to take a long time to complete their work.

Let's see an example of how they can be used in a console app, and then, later, you will see them used in a more practical example within web projects.

# Improving responsiveness for console apps

One of the limitations with console apps is that you can only use the `await` keyword inside methods that are marked as `async`, but C# 7 and earlier do not allow the `Main` method to be marked as `async`! Luckily, a new feature introduced in C# 7.1 was support for `async` in the `Main` method.

Let's see it in action:
1.	Use your preferred code editor to add a new **Console App** / `console` project named `AsyncConsole` to the `Chapter02` solution.
2.	In the `AsyncConsole.csproj` file, after the `<PropertyGroup>` section, add a new `<ItemGroup>` section to statically import `System.Console` for all C# files using the implicit usings .NET SDK feature, as shown in the following markup:
```xml
<ItemGroup>
  <Using Include="System.Console" Static="true" />
</ItemGroup>
```

3.	In `Program.cs`, delete the existing statements, and then add statements to create an `HttpClient` instance, make a request for Apple's home page, and output how many bytes it has, as shown in the following code:
```cs
HttpClient client = new();

HttpResponseMessage response =
  await client.GetAsync("http://www.apple.com/");

WriteLine("Apple's home page has {0:N0} bytes.",
  response.Content.Headers.ContentLength);
```

4.	Navigate to **Build** | **Build AsyncConsole** and note that the project builds successfully.

> In .NET 5 and earlier, you would have seen an error message, as shown in the following output:
`Program.cs(14,9): error CS4033: The 'await' operator can only be used within an async method. Consider marking this method with the 'async' modifier and changing its return type to 'Task'.` You would have had to add the `async` keyword for your `Main` method and change its return type from `void` to `Task`. With .NET 6 and later, the console app project template uses the top-level program feature to automatically define the `Program` class with an `async` `<Main>$` method for you.

5.	Run the code and view the result, which is likely to have a different number of bytes since Apple changes its home page frequently, as shown in the following output:
```
Apple's home page has 170,688 bytes.
```
