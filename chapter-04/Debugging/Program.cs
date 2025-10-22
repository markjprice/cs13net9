double a = 4.5;
double b = 2.5;
double answer = Add(a, b);

WriteLine($"{a} + {b} = {answer}");
WriteLine("Press Enter to end the app.");
ReadLine(); // Wait for user to press Enter.

// Functions in Program.cs must be at the bottom of the file.
double Add(double a, double b)
{
    return a + b; // deliberate bug!
}
