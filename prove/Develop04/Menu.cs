using System.Runtime.InteropServices;

class Menu
{   
    private string[] menuItems = {
        "Breathing Activity",
        "Reflecting Activity",
        "Listing Activity",
        "Quit"
    };

    public bool ChooseAndRun()
    {
        Console.Clear();
        Console.WriteLine("\nMenu Options:");
        for (int i = 0; i < menuItems.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {menuItems[i]}");
        }
        
        Console.Write("Select a choice from the menu: ");
        int choice = Convert.ToInt32(Console.ReadLine());
        Console.Clear();

        switch (choice)
        {
            case 1:
                Breathing breathing = new Breathing();
                breathing.Run();
                break;
            case 2:
                Reflecting reflecting = new Reflecting();
                reflecting.Run();
                break;
            case 3:
                Listing listing = new Listing();
                listing.Run();
                break;
            case 4:
                Console.WriteLine("Goodbye!");
                return false;
            default:
                Console.WriteLine("Invalid option please try again.");
                break;
        }
        return true;
    }
}