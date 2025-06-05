using System.ComponentModel;

string[] names; //can be an array of any size

names = new string[4]; //allocate memory for four strings in an array

//Store items at these index postitions'
names[0] = "kate";
names[1] = "jack";
names[2] = "rebecca";
names[3] = "tom";

string[] names2 = { "kate", "jack", "rebecca", "tom" };

for (int i = 0; i < names2.Length; i++)
{
    Console.WriteLine($"{names2[i]} is at postion {i}");
}



//Two dimensional arrays
string[,] grid1 =
{
    {"alpha", "beta", "gamma", "delta"},
    {"anne", "ben", "charlie", "doug"},
    {"aardvark", "bear", "cat", "dog"}
};
Console.WriteLine($"1st dimension, lower bound: {grid1.GetLowerBound(0)}");
Console.WriteLine($"1st dimension, upper bound: {grid1.GetUpperBound(0)}");
Console.WriteLine($"2nd dimension, lower bound: {grid1.GetLowerBound(1)}");
Console.WriteLine($"2nd dimension, lower bound: {grid1.GetUpperBound(1)}");
//How to output elements of a multi-demensioanl array
for (int row = 0; row <= grid1.GetUpperBound(0); row++)
{
    for (int col = 0; col <= grid1.GetUpperBound(1); col++)
    {
        Console.WriteLine($"Row {row}, column {col}: {grid1[row, col]}");
    }
}


//Jagged Array: Multi-Dimenstional array but number of items stored in each row/dimension are different
string[][] jagged =
{
    new[] {"alpha", "beta", "gamma"},
    new[] { "anne", "ben", "charlie", "doug" },
    new[] { "aardvark", "bear" }
};

Console.WriteLine("Upperbound of the arrayis : {0}", jagged.GetUpperBound(0));
for (int array = 0; array <= jagged.GetUpperBound(0); array++)
{
    Console.WriteLine("Upperbound of array {0} is : {1}", arg0: array, arg1: jagged[array].GetUpperBound(0));
}