using System;

class Program
{
    static void Main(string[] args)
    {
        Menu menu = new Menu();

        bool keepRunning = true;
        while(keepRunning)
        {
            keepRunning = menu.ChooseAndRun();
        }
    }
}