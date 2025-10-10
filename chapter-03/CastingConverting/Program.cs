using static System.Convert;
using static System.Object;
using System.Globalization; //To use culture info+

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

#endregion