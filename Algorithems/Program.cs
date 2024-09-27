// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

int[] arrayList = new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 };

int currentSum = 0;
int maxSum = int.MinValue;

foreach (int num in arrayList)
{
    currentSum = Math.Max(num, currentSum + num);
    maxSum = Math.Max(maxSum, currentSum);
}

Console.WriteLine(maxSum);
    Console.ReadKey();