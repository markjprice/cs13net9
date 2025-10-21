partial class Program
{
    static void TimesTable(byte number, byte size = 12)
    {
        Console.WriteLine($"This is the {number} times table with {size} rows: ");
        Console.WriteLine();

        for (int row = 1; row <= size; row++)
        {
            Console.WriteLine($"{row} x {number} = {row * number}");
        }
        Console.WriteLine();
    }
}