**Improvements** (1 items)

If you have suggestions for improvements, then please [raise an issue in this repository](https://github.com/markjprice/cs13net9/issues) or email me at markjprice (at) gmail.com.

- [Page 15 - Listing and removing versions of .NET](#page-15---listing-and-removing-versions-of-net)


# Page 15 - Listing and removing versions of .NET

> Thanks to [s3ba-b](https://github.com/s3ba-b) who raised this [issue on November 5, 2024](https://github.com/markjprice/cs12dotnet8/issues/75).

In the first paragraph I wrote, ".NET runtime updates are compatible with a major version such as 8.x, and updated releases of the .NET SDK maintain the ability to build applications that target previous versions of the runtime, which enables the safe removal of older versions."

This could be clearer, so in the 10th edition*, I will write soemthing like: 

"All future versions of the .NET 10 runtime are compatible with its major version. For example, if a project targets `net10.0`, then you can upgrade the .NET runtime to future versions like `10.0.1`, `10.0.2`, and so on. In fact, you *must* upgrade the .NET runtime every month to maintain support."

"All future versions of the .NET SDK maintain the ability to build projects that target previous versions of the runtime. For example, if a project targets `net10.0` and you initially build it using .NET SDK `10.0.100`, then you can upgrade the .NET SDK to future bug fix versions like `10.0.101` or a major version like `11.0.100`, and that SDK can still build the project for the older targetted version. This means that you can safely remove all older versions of any .NET SDKs like `8.0.100`, `9.0.100`, or `10.0.100`, after you've installed a .NET SDK 11 or later. You will still be able to build all your old projects that target those older versions."

*It was too late to make this improvement in the 9th edition. 

