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

        DateTime currentTime = DateTime.Now;
        string Date = currentTime.ToString("yyyy-MM-dd");
        string datePrompt = $"Date: {Date} - Prompt: {prompt}";

        this.entryList.Add(datePrompt);
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
        Console.WriteLine("");   
        Console.Write("What is the filename? ");
        string filename = Console.ReadLine();
        if (File.Exists(filename)) {
            Console.WriteLine("The file is already exist. The file will be replace.");
            Console.Write("Are you sure you still want to save as this file name? (Y/N)");
            string answer = Console.ReadLine();
            if (answer.ToLower() == "y" || answer.ToLower() == "yes") {
                using (StreamWriter saveFile = new StreamWriter(filename)) {   
                    foreach (string line in this.entryList){
                    saveFile.WriteLine(line);
                    }
                }
            }
            else if (answer.ToLower() == "n" || answer.ToLower() == "no") {
                Console.WriteLine("Please enter the file name let you want to save again.");
                Console.Write("What is the filename? ");
                filename = Console.ReadLine();
                using (StreamWriter saveFile = new StreamWriter(filename))
                {   
                    foreach (string line in this.entryList){
                    saveFile.WriteLine(line);
                    }
                }
            }

        }
        else{
            using (StreamWriter saveFile = new StreamWriter(filename))
            {   
                foreach (string line in this.entryList){
                saveFile.WriteLine(line);
                }
            }
        }
    }
    public void Load()
    {   
        Entry entry = new Entry();
        Console.Write("What is the filename? ");
        string filename = Console.ReadLine();
        this.entryList = entry.loadFile(filename);
    }
}