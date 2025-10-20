#region Loops and Overflow
int max = 500;
for (byte i = 0; i < max;)
{
    Console.WriteLine(i);

    try
    {
        checked
        {
            i++;
        }
    }
    catch (OverflowException)
    {
        //If increment ocerflow the byte, break to avoid infinite loop
        break;
    }
}

#endregion

#region FizzBuzz

int maxNumber = 100;

bool buzz = false;
bool fizz = false;

for (int i = 1;  i < maxNumber; i++)
{
    fizz = i % 3 == 0;
    buzz = i % 5 == 0;

    if (fizz && buzz)
    {
        Console.WriteLine("FizzBuzz");
    }
    else if (fizz)
    {
        Console.WriteLine("Fizz");
    }
    else if (buzz)
    {
        Console.WriteLine("Buzz");
    }
    else
    {
        Console.WriteLine(i);
    }
}

#endregion