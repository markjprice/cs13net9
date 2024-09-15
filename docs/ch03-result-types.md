**Returning result types versus throwing exceptions**

In .NET programming, handling errors often revolves around two primary mechanisms: exceptions and result types. Both have their advocates, and the debate between them touches on various aspects of software design, performance, and usability.

- [Exceptions in .NET](#exceptions-in-net)
- [Result Types in .NET](#result-types-in-net)
- [Libraries Available to Implement Result Types](#libraries-available-to-implement-result-types)
- [Discriminated Unions and Their Relation to the Discussion](#discriminated-unions-and-their-relation-to-the-discussion)
- [Conclusion](#conclusion)

# Exceptions in .NET
Exceptions are the traditional way of handling errors in .NET and many other languages. When an error occurs, an exception is thrown, and the execution of the program is transferred to the nearest matching exception handler. .NET has a robust exception hierarchy with the `System.Exception` class as the base. Here's a breakdown of the key points in favor of and against exceptions:

The pros of exceptions include the following list:

- **Separation of Concerns**: Exception handling separates error-checking logic from normal program flow, making the code more readable and focusing on the "happy path."
- **Rich Information**: Exceptions can carry detailed information (stack traces, inner exceptions) that can be invaluable for debugging.
- **Built-In Support**: Exceptions are deeply integrated into the .NET framework and runtime, providing a familiar model for error handling.

The cons of exceptions include the following list:

- **Performance**: Throwing and catching exceptions is significantly more expensive than simple control flow constructs. It involves stack unwinding and can impact performance, especially in scenarios where errors are expected to occur frequently.
- **Hidden Control Flow**: Exceptions can obscure program flow, making the code harder to reason about. This can lead to bugs, particularly when developers are unaware of all possible exception types that might be thrown.
- **Overuse**: Some developers misuse exceptions for normal control flow (e.g., to check if a value is present in a collection), which goes against best practices and leads to performance degradation.

# Result Types in .NET

Result types (also known as "option types" or "either types") are an alternative pattern for error handling, often seen in functional programming languages. In the .NET world, result types are used to explicitly indicate the success or failure of an operation without relying on exceptions.

A common implementation of a result type in .NET might look like this:
```cs
public class Result<T>
{
    public T Value { get; }
    public bool IsSuccess { get; }
    public string ErrorMessage { get; }

    private Result(T value, bool isSuccess, string errorMessage)
    {
        Value = value;
        IsSuccess = isSuccess;
        ErrorMessage = errorMessage;
    }

    public static Result<T> Success(T value) => new Result<T>(value, true, null);
    public static Result<T> Failure(string errorMessage) => new Result<T>(default, false, errorMessage);
}
```

The pros of using result types include the following list:

- **Explicit Error Handling**: Result types make error handling an explicit part of the API. Consumers of the method must handle both success and failure cases, leading to safer and more predictable code.
- **Performance**: Result types don't involve the overhead of stack unwinding or other exception-handling mechanics, making them more performant in scenarios with frequent errors.
- **Easier Testing**: Methods that return result types can be easier to test since they provide a clear contract of possible outcomes.

The cons of using result types include the following list:

- **Verbosity**: Using result types can lead to more boilerplate code, as every operation involving potential errors requires handling both success and failure explicitly.
- **Cumbersome for Complex Flows**: For deeply nested or complex operations, explicitly managing result types can become unwieldy, especially compared to the straightforward "try-catch" model.
- **Not Idiomatic**: Result types are not idiomatic in all .NET libraries and frameworks, which primarily rely on exceptions for error handling. This can lead to inconsistency in codebases that mix both paradigms.

# Libraries Available to Implement Result Types

Several libraries and packages provide implementations of result types in .NET:

Library|Description
---|---
[LanguageExt](https://github.com/louthy/language-ext)|A functional programming library for .NET, `LanguageExt` provides `Option`, `Either`, and `Try` types that allow you to handle errors and control flow in a functional style.
[CSharpFunctionalExtensions](https://github.com/vkhorikov/CSharpFunctionalExtensions)|This library offers a `Result<T>` type and extension methods that make it easier to work with results in a functional manner. It also provides support for optional values and error chaining.
[OneOf](https://github.com/mcintyre321/OneOf)|This library provides a simple discriminated union (or sum type) implementation that allows you to represent a value that could be one of several different types. It can be used to create custom result types where different failure modes return different types.
[Optional](https://github.com/Foritus/optional-dot-net)|A lightweight library that provides an `Option<T>` type for representing optional values (similar to `Nullable<T>` but for reference types and non-nullable value types).
[ErrorOr](https://github.com/amantinband/error-or)|A simple, fluent discriminated union of an error or a result.
[FluentResults](https://github.com/altmann/FluentResults)|A lightweight .NET library developed to solve a common problem. It returns an object indicating success or failure of an operation instead of throwing/using exceptions.

# Discriminated Unions and Their Relation to the Discussion

Discriminated unions (also known as "sum types" or "tagged unions") are types that can represent a value that could be one of several fixed types. In languages like F# (part of the .NET ecosystem), discriminated unions are built into the language. For example:
```fsharp
type Result<'T> =
    | Success of 'T
    | Failure of string
```

In the context of result types, discriminated unions allow a function to return a value that clearly indicates its possible outcomes (success or various error types). This is especially useful when there are multiple failure modes that need to be handled differently.

In C#, discriminated unions are not (yet) a built-in feature, but they can be emulated using class hierarchies, `enum` types, or libraries like `OneOf`. The relationship to the exceptions vs. result types discussion lies in how discriminated unions make error-handling patterns explicit, type-safe, and more aligned with functional programming practices.

> **More Information**: You can read the proposal, Type Unions for C#, at the following link: https://github.com/dotnet/csharplang/blob/18a527bcc1f0bdaf542d8b9a189c50068615b439/proposals/TypeUnions.md. You can read an earlier discussion at the following link: https://github.com/dotnet/csharplang/discussions/399.

# Conclusion

Use exceptions in .NET when errors are truly exceptional and not part of the regular control flow. This is especially true for libraries and APIs that interact with .NET's built-in frameworks, which expect exceptions as the primary error mechanism.

Use result types when errors are expected to occur frequently, and you want to make error handling explicit and type-safe. Result types can be particularly useful in functional programming styles or applications where control flow needs to be clear and predictable.

Discriminated unions are directly related to result types, providing a way to represent operations with multiple possible outcomes in a clear, type-safe manner. Libraries like OneOf bring discriminated union-like constructs into C#.

In practice, many projects in .NET end up using a hybrid approach, reserving exceptions for truly unexpected errors and employing result types (or nullable references) for routine error-checking scenarios. The key is to be consistent within your codebase and mindful of the performance and maintenance implications of the chosen error-handling strategy.
