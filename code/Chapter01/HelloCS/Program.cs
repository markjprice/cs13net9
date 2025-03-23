// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, C#!");

string name = typeof(Program).Namespace ?? "<null>";
string name1 =typeof(Program).FullName ?? "<null>";
Console.WriteLine($"Namespace1:{name1}");
Console.WriteLine($"Namespace: {name}");

throw new Exception();
int z;
