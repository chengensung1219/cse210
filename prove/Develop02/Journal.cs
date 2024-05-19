using System;
using System.Formats.Asn1;
using System.IO;
class Journal
{   
    List<string> entryList = new List<string>();
    public void Write() {   
        
        Entry entry = new Entry();

        string prompt = PromptGenerator.GetRandomPrompt();
        Console.WriteLine(prompt);

        Console.Write("> ");
        string newEntry = Console.ReadLine();

        Console.Write("Rate your current feeling from 1 to 5 (1 is WORST & 5 is BEST) ");
        string mood = Console.ReadLine();
        string moodString = $"Feeling: {mood}";

        DateTime currentTime = DateTime.Now;
        string Date = currentTime.ToString("yyyy-MM-dd");
        string dateMood = $"Date: {Date} - Mood Rate: {moodString}";
        string promptString = $"Prompt: {prompt}";

        this.entryList.Add(dateMood);
        this.entryList.Add(promptString);
        this.entryList.Add(newEntry);
        this.entryList.Add("");

    }

    public void Display()
    {   

        foreach (string line in this.entryList){
            Console.WriteLine(line);
        }
    }

    public void Save()
    {   
        Entry entry = new Entry();
        Console.WriteLine("");
        Console.Write("What is the filename? [Not include the file type (txt, csv, json...etc)] ");
        string filename = Console.ReadLine();
        Console.Write("Do you want a TXT file? (Y/N) ");
        string YesTXT = Console.ReadLine();
        if (YesTXT.ToLower() == "y" || YesTXT.ToLower() == "yes") {
            entry.saveTXTFile(filename, this.entryList);

        }
        else if (YesTXT.ToLower() == "n" || YesTXT.ToLower() == "no") {
            
        }
        Console.Write("Do you want a CSV file? (Y/N) ");
        string YesCSV = Console.ReadLine();
        if (YesCSV.ToLower() == "y" || YesCSV.ToLower() == "yes") {
            entry.saveCSVFile(filename, this.entryList);

        }
        else if (YesCSV.ToLower() == "n" || YesCSV.ToLower() == "no") {
            
        }

        Console.Write("Do you want a JSON file? (Y/N) ");
        string YesJSON = Console.ReadLine();
        if (YesJSON.ToLower() == "y" || YesJSON.ToLower() == "yes") {
            entry.saveJSONFile(filename, this.entryList);

            
        }
        else if (YesJSON.ToLower() == "n" || YesJSON.ToLower() == "no") {
            
        }
        
    }
    public void Load()
    {   
        Entry entry = new Entry();
        Console.Write("What is the filename? [Please include the file type (txt, csv, json...etc)] ");
        string filename = Console.ReadLine();
        this.entryList = entry.loadFile(filename);
        Console.WriteLine($"File {filename} has been saved successfully.\n");
    }
}