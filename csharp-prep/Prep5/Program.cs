using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayMessage();
        string name = PromptUserName();
        int favNumber = PromptUserNumber();
        int squareNumber = SquareNumber(favNumber);
        DisplayResult(squareNumber, name);

    }
    static void DisplayMessage()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int favNumber = int.Parse(Console.ReadLine());
        return favNumber;
    }
    static int SquareNumber(int number)
    {
        int squareNumber = number * number;
        return squareNumber;
    }
    static void DisplayResult(int squareNumber, string name)
    {
        Console.WriteLine($"{name}, the square of your number is {squareNumber}");
    }
}