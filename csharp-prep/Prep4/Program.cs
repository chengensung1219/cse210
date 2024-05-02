using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        float totalValue = 0;
        float times = 0;
        float average;
        int largestNumber = 0;
        int smallestPosNumber = 100000000;
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        Console.Write("Enter number: ");
        int addNumber = int.Parse(Console.ReadLine());

        while (addNumber != 0){
            numbers.Add(addNumber);
            totalValue = addNumber + totalValue; 
            times += 1;
            if (addNumber > largestNumber){
                largestNumber = addNumber;
            }
            else if (addNumber < smallestPosNumber && addNumber > 0){
                smallestPosNumber = addNumber;
            }
            Console.Write("Enter number: ");
            addNumber = int.Parse(Console.ReadLine());
        }
        average = totalValue / times;
        Console.WriteLine($"The sum is: {totalValue}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largestNumber}");
        Console.WriteLine($"The smallest positive number is: {smallestPosNumber}");
        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (int number in numbers){
            Console.Write(number + " ");
            Console.WriteLine();
        }
    }
}