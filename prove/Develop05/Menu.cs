using System;
using System.Runtime.InteropServices;

class Menu
{   
    private int once = 0;
    SettingGoal setting = new SettingGoal();
    private string[] menuItems = {
        "Create New Goal",
        "List Goals",
        "Save Goals",
        "Load Goals",
        "Record Event",
        "Delete Goal",
        "Quit"
    };

    public bool ChooseAndRun()
    {   
        if (once < 1) {
            if (File.Exists("backup.json")){
                setting.LoadGoalsToJson();
            }
            once += 1;
        }
        int totalpoints = setting.GetTotalpoints();
        Console.WriteLine($"\nYou have {totalpoints} point.");
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
                setting.ChooseAndRun();
                break;
            case 2:
                setting.DisplayGoals();
                break;
            case 3:
                Console.Write("What is the JSON filename? [Not include the file type (.json)] ");
                string name = Console.ReadLine();
                setting.SaveGoalsToJson(name);
                setting.Loading("save");
                break;
            case 4:
                Console.Write("What is the JSON filename? [Not include the file type (.json)] ");
                name = Console.ReadLine();
                setting.LoadGoalsToJson(name);
                setting.Loading("load");
                break;
            case 5:
                setting.RecordEvent();
                break;
            case 6:
                setting.DeleteGoal();
                break;
            case 7:
                setting.SaveGoalsToJson();
                setting.Loading("autosave");
                Console.WriteLine($"\nGoodbye!");
                return false;
            default:
                Console.WriteLine("Invalid option please try again.");
                break;
        }
        return true;
    }
}