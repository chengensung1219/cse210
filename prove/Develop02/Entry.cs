using System;
using System.IO;
using System.Xml.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
class Entry
{   
    private List<string> loadEntryList = new List<string>();

    public List<string> loadFile(string filename) {
        string[] lines = System.IO.File.ReadAllLines(filename);

        foreach (string line in lines)
        {   
            string newLine = line.Replace("\"", "");
            this.loadEntryList.Add(newLine);
        }
        return loadEntryList;
    }
    
    public void saveTXTFile(string name, List<string> entryList) {

        string filename = $"{name}.txt";

        if (File.Exists(filename)) {
            Console.WriteLine("The file is already exist. The file will be replace.");
            Console.Write("Are you sure you still want to save the file as this file name? (Y/N) ");
            string answer = Console.ReadLine();

            if (answer.ToLower() == "y" || answer.ToLower() == "yes") {

                WriteToTXTorCSVFile(filename, entryList);
            }
            else if (answer.ToLower() == "n" || answer.ToLower() == "no") {
                Console.WriteLine("Please enter the file name let you want to save again.");
                Console.Write("What is the filename? [Not include the file type (txt, csv, json...etc)] ");
                name = Console.ReadLine();

                filename = $"{name}.txt";
                WriteToTXTorCSVFile(filename, entryList);
            }

        }
        else{
            WriteToTXTorCSVFile(filename, entryList);
        }
    }
    public void saveCSVFile(string name, List<string> entryList) {

        string filename = $"{name}.csv";

        if (File.Exists(filename)) {
            Console.WriteLine("The file is already exist. The file will be replace.");
            Console.Write("Are you sure you still want to save the file as this file name? (Y/N) ");
            string answer = Console.ReadLine();

            if (answer.ToLower() == "y" || answer.ToLower() == "yes") {

                WriteToTXTorCSVFile(filename, entryList);
            }
            else if (answer.ToLower() == "n" || answer.ToLower() == "no") {
                Console.WriteLine("Please enter the file name let you want to save again.");
                Console.Write("What is the filename? [Not include the file type (txt, csv, json...etc)] ");
                name = Console.ReadLine();
                filename = $"{name}.txt";

                WriteToTXTorCSVFile(filename, entryList);
            }

        }
        else{
            WriteToTXTorCSVFile(filename, entryList);
        }

    }
    public void saveJSONFile(string name, List<string> entryList)
    {
        string filename = $"{name}.json";

        if (File.Exists(filename))
        {
            Console.WriteLine("The file already exists. The file will be replaced.");
            Console.Write("Are you sure you still want to save the file as this file name? (Y/N) ");
            string answer = Console.ReadLine();

            if (answer.ToLower() == "y" || answer.ToLower() == "yes")
            {
                WriteToJASONFile(filename, entryList);
            }
            else if (answer.ToLower() == "n" || answer.ToLower() == "no")
            {
                Console.WriteLine("Please enter the file name you want to save again.");
                Console.Write("What is the filename? [Do not include the file type (txt, csv, json, etc.)] ");
                name = Console.ReadLine();
                filename = $"{name}.json";
                WriteToJASONFile(filename, entryList);
            }
        }
        else
        {
            WriteToJASONFile(filename, entryList);
        }
    }

    private static void WriteToJASONFile(string filename, List<string> entryList)
    {
        string jsonString = JsonSerializer.Serialize(entryList, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filename, jsonString);
        Console.WriteLine($"File {filename} has been saved successfully.\n");
    }
    private static void WriteToTXTorCSVFile(string filename, List<string> entryList)
    {
        using (StreamWriter saveFile = new StreamWriter(filename))
        {   
            foreach (string line in entryList) {
            saveFile.WriteLine($"\"{line}\"");
            }
        }
        Console.WriteLine($"File {filename} has been saved successfully.\n");
    }
}


