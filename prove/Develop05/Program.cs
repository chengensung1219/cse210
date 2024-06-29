using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Menu menu = new Menu();

        bool keepRunning = true;
        while(keepRunning)
        {
            keepRunning = menu.ChooseAndRun();
        }
    }
}