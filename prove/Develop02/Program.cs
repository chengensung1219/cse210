using System;

class Program
{
    public static void Main(string[] args) {
        
        Journal journal = new Journal();

        Console.WriteLine("Welcome to the Journal Program!\n");

        List<string> menu = ["Write", "Display", "Load", "Save", "Quit"];

        while (true){

            Console.WriteLine("Please select one of the following choices: ");

            for (int i = 0; i < menu.Count; i++){
                Console.WriteLine($"{i + 1}. {menu[i]}");
            }

            Console.Write("What would you like to do? ");
            string choice = Console.ReadLine();

            if (choice == "1") {
                journal.Write();
            }
            else if (choice == "2") {
                journal.Display();
            }
            else if (choice == "3") {
                journal.Load();
            }
            else if (choice == "4") {
                journal.Save();
            }
            else if (choice == "5") {
                Console.WriteLine("Thank you!!! Wish you have a great day today.");
                break;
            }
            else {
                Console.WriteLine("Invalid choice");
                Console.WriteLine($"Please choice again.");
            }
        }
    }
}