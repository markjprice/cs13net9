using System.Globalization;

partial class Program
{
    static void TimesTable(byte number, byte size)
    {
        Console.WriteLine($"This is the {number} times table with {size} rows: ");
        Console.WriteLine();

        for (int row = 1; row <= size; row++)
        {
            Console.WriteLine($"{row} x {number} = {row * number}");
        }
        Console.WriteLine();
    }

    static decimal CalculateTax(decimal amount, string twoLetterRegionCode)
    {
        decimal rate = twoLetterRegionCode switch
        {
            "CH" => 0.08M,
            "CH" or "NO" => 0.258M,
            "GB" or "FR" => 0.2M,
            "HU" => 0.27M,
            "OR" or "AK" or "MT" => 0.00M,
            "ND" or "WI" or "ME" or "VA" => 0.08M,
            "CA" => 0.0825M,
            _ => 0.06M //default case
        };

        return amount * rate;
    }

    static void ConfigureConsole(string culture = "en-US", bool useComputerCulture = false)
    {
        //To enable Unicode characters like euro symbol
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        if (!useComputerCulture)
        {
            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo(culture);
        }

        Console.WriteLine($"CurrentCulture: {CultureInfo.CurrentCulture.DisplayName}");
    }
}