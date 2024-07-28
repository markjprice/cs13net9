using System.Text.RegularExpressions; // To use [GeneratedRegex].

partial class Program
{
  [GeneratedRegex(DigitsOnlyText, RegexOptions.IgnoreCase)]
  private static partial Regex DigitsOnly { get; }

  [GeneratedRegex(CommaSeparatorText, RegexOptions.IgnoreCase)]
  private static partial Regex CommaSeparator { get; }
}
