Console.WriteLine("Enter a number between 0 and 255: ");

byte min = 0;
byte max = 255;
byte output1 = 0; 
byte output2 = 0;
int result;

while (true)
{
    string? input1 = Console.ReadLine();

    if (byte.TryParse(input1, out output1))
    {
        if (output1 >= min && output1 <= max)
        {
            Console.WriteLine("Enter another number between 0 and 255: ");
            break;
        }
        else
        {
            Console.WriteLine($"{output1} is out of bounds");
        }
    }
    else
    {
        Console.WriteLine($"{input1} is not a valid byte");
    }
}

while (true)
{
    string? input2 = Console.ReadLine();

    if (byte.TryParse(input2, out output2))
    {
        if (output2 >= min && output2 <= max)
        {
            Console.WriteLine("Computing answer");
            break;
        }
        else
        {
            Console.WriteLine($"{output2} is out of bounds");
        }
    }
    else
    {
        Console.WriteLine($"{input2} is not a valid ineger");
    }
}

try
{
    result = output1 / output2;
    Console.WriteLine(result);
}
catch (DivideByZeroException ex)
{
    Console.WriteLine(ex.Message);
}

