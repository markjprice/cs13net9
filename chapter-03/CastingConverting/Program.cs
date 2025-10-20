using static System.Convert;
using static System.Object;
using System.Globalization; //To use culture info+
using static System.Exception; //To declare an Exception ex in catch 

#region Casting numbers implicitly and explicitly
int a = 10;
double b = a; //int can be casted to a double 
Console.WriteLine($"a is {a} and b is {b}");

double c = 9.8;
int d = (int)c; //use casting opeator to explictiy cast down 
Console.WriteLine($"c is {c} and d id {d}");

long e = 10;
int f = (int)e;
Console.WriteLine($"e is {e} and f is {f}");

e = long.MaxValue;
f = (int)e;
Console.WriteLine($"e is {e} and f is {f}");
#endregion

#region Converting with Convert type
double g = 9.8;
int h = ToInt32(g);
Console.WriteLine($" g is {g} and h is {h}");
#endregion

#region Rounding Numbers and default rounding rules
double[,] doubles = {
  { 9.49, 9.5, 9.51 },
  { 10.49, 10.5, 10.51 },
  { 11.49, 11.5, 11.51 },
  { 12.49, 12.5, 12.51 },
  { -12.49, -12.5, -12.51 },
  { -11.49, -11.5, -11.51 },
  { -10.49, -10.5, -10.51 },
  { -9.49, -9.5, -9.51 }
};

Console.WriteLine($"| double | ToInt32 | double | ToInt32 | double | ToInt32 |");
for (int x = 0; x < 8; x++)
{
    for (int y = 0; y < 3; y++)
    {
        Console.Write($"| {doubles[x, y],6} | {ToInt32(doubles[x, y]),7} ");
    }
    Console.WriteLine("|");
}
Console.WriteLine();

//-12.5 will round to -12 towards 0 as its a positive numnber and -9.5 will round to -10 away from 0 as its negative 
//This is known as Banker's Rounding
#endregion

#region Taking Control of Rounding Rules
foreach (double n in doubles)
{
    Console.WriteLine(format:
      "Math.Round({0}, 0, MidpointRounding.AwayFromZero) is {1}",
      //Code below will round all positive and negative numbers away from zero
      arg0: n,
      arg1: Math.Round(value: n, digits: 0,
              mode: MidpointRounding.AwayFromZero));
}
#endregion

#region Converting From any type to a String
int number = 12;
Console.WriteLine(number.ToString());

bool boolean = true;
Console.WriteLine(boolean.ToString());

DateTime now = DateTime.Now;
Console.WriteLine(now.ToString());

object me = new();
Console.WriteLine(me.ToString());
#endregion

#region Parsing from Strings to Numbers or Dates and Times
//Set the current culture to make sure data parsing works
CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-US");

int friends = int.Parse("27");
DateTime birthday = DateTime.Parse("4 June 1980");
Console.WriteLine($"Number of friends at the party on {birthday} is {friends}");
Console.WriteLine($"Output on the date using {birthday:D}"); //format is Wendsday, June 5th, 1980
#endregion

#region Avoid Parse Exceptions by using TryParse Method
Console.Write("How many chickens are there? ");
string? input = Console.ReadLine();
if (int.TryParse(input, out int count))
{
    Console.WriteLine($"There are {input} chickens");
}

else
{
    Console.WriteLine("Invalid Input");
}
#endregion

Console.WriteLine();

#region Wrapping error prone code in a try black
Console.WriteLine("Before Parsing!");
Console.Write("What is your age?");
string? input2 = Console.ReadLine();

try
{
    int age = int.Parse(input2);
    Console.WriteLine($"You are {age} years old");
}

catch (OverflowException)
{
    // Thrown when the parsed numeric value is outside the range of the target type
    // (e.g., the entered number is larger than int.MaxValue or smaller than int.MinValue).
    Console.WriteLine("Your age is a valid number format but is either too large or small");
}
catch (FormatException)
{
    // Thrown when the input string is not in a valid numeric format
    // (e.g., contains letters, symbols, or is otherwise unparsable as an integer).
    Console.WriteLine("The age you entered is not a valid number");
}
catch (Exception ex)
{
    // Catches any other unexpected exceptions as a fallback.
    // Prints the runtime exception type and its message for diagnostic purposes.
    Console.WriteLine($"{ex.GetType()} says {ex.Message}");
}

Console.WriteLine("After parsing.");
#endregion

Console.WriteLine();

#region Catching with filters
//How to format a decimal to currency
Console.Write("Enter an amount: ");
string? amount = Console.ReadLine()!; //null-forgiving operator...assures compilter variable is not null
if (string.IsNullOrEmpty(amount)) return;

try
{
    decimal amountValue = decimal.Parse(amount);
    Console.WriteLine($"Amount formatted is currency: {amountValue:C}");
}
catch (FormatException) when (amount.Contains('$'))
{
    Console.WriteLine("Amounts cannot use the dollar sign");
}
catch (FormatException)
{
    Console.WriteLine("Amount must only contain digits");
}
#endregion

Console.WriteLine();

#region Throwing overflow exceptions with the checked statement 
// The `checked` statement forces runtime checking of arithmetic operations in this block.
// If an arithmetic operation (like incrementing `z`) exceeds the range of `int`,
// the runtime throws an `OverflowException` instead of silently wrapping the value.
try
{
    checked
    {
        int z = int.MaxValue - 1;
        Console.WriteLine($"Initial value: {z}");
        z++;
        Console.WriteLine($"After incrementing: {z}");
        z++;
        Console.WriteLine($"After incrementing: {z}");
        z++;
        Console.WriteLine($"After incrementing: {z}");
    }
}
catch (OverflowException)
{
    Console.WriteLine("Code overflowed but exception caught");
}
#endregion

