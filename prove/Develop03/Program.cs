using System;
using System.Net.Mime;

class Program
{
    static void Main()
    {   
        Memorize memorize = new Memorize();

        memorize.DefaultFile();

        List<string> menu = ["Start to memorize", "Load scripture file", "Quit"];

        while (true){

            Console.WriteLine("Please select one of the following choices: \n");

            for (int i = 0; i < menu.Count; i++){
                Console.WriteLine($"{i + 1}. {menu[i]}");
            }

            Console.Write("\nWhat would you like to do? ");
            string choice = Console.ReadLine();

            if (choice == "1") {
                memorize.MemorizeScripture();
            }
            else if (choice == "2") {
                memorize.LoadFile();
                
            }
            else if (choice == "3") {
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