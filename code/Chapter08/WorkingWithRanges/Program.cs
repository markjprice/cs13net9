#region Using indexes, ranges, and spans

string name = "Samantha Jones";

// Getting the lengths of the first and last names.
int lengthOfFirst = name.IndexOf(' ');
int lengthOfLast = name.Length - lengthOfFirst - 1;

// Using Substring.
string firstName = name.Substring(
  startIndex: 0,
  length: lengthOfFirst);

string lastName = name.Substring(
  startIndex: name.Length - lengthOfLast,
  length: lengthOfLast);

WriteLine($"First: {firstName}, Last: {lastName}");

// Using spans.
ReadOnlySpan<char> nameAsSpan = name.AsSpan();
ReadOnlySpan<char> firstNameSpan = nameAsSpan[0..lengthOfFirst];
ReadOnlySpan<char> lastNameSpan = nameAsSpan[^lengthOfLast..];

WriteLine($"First: {firstNameSpan}, Last: {lastNameSpan}");

#endregion

#region Using spans for efficient text handling

ReadOnlySpan<char> text = "12+23+456".AsSpan();

int sum = 0;
foreach (Range r in text.Split('+'))
{
  sum += int.Parse(text[r]);
}
WriteLine($"Sum using Split: {sum}");

#endregion

#region Test your knowledge
/*
string city = "Aberdeen";
ReadOnlySpan<char> citySpan = city.AsSpan()[^5..^0];
WriteLine(citySpan.ToString());
*/
#endregion