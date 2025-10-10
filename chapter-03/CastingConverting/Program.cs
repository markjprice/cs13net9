using static System.Convert;

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

