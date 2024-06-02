using System;

class Memorize{

    private List<string> oldReferences = new List<string>();

    private List<string> scriptures = new List<string>();

    private List<string> references = new List<string>(); 

    private string content;

    private string source;

    private string[] splitSource;
    
    private Scripture scripture;

    public void DefaultFile(){
        string[] lines = System.IO.File.ReadAllLines("list.txt");

        foreach (string line in lines)
        {   
            string newLine = line.Replace("\"", "");
            string[] splitNewLine = newLine.Split("|");
            oldReferences.Add(splitNewLine[0]);
            scriptures.Add(splitNewLine[1]);
        }
    }

    public void ModifiedReference(List<string> oldReferences){
        foreach (string item in oldReferences) {
            string firstModified = item.Replace(' ', ',');
            string secondModified = firstModified.Replace(':', ',');
            string finalModified = secondModified.Replace('-', ',');
            references.Add(finalModified);
        }
    }

    public void MemorizeScripture(){

        
        for (int i = 0; i < oldReferences.Count; i++){

            Console.WriteLine($"\n{i + 1}. {oldReferences[i]}");
        }
        Console.Write("\nWhich scripture would you like to choose? ");
        string choice = Console.ReadLine();

        ModifiedReference(oldReferences);

        if (choice == "1") {
            this.content = this.scriptures[0];
            this.source = this.references[0];
            this.splitSource = source.Split(",");
        }
        else if (choice == "2") {
            this.content = this.scriptures[1];
            this.source = this.references[1];
            this.splitSource = source.Split(",");
        }
        else if (choice == "3") {
            this.content = this.scriptures[2];
            this.source = this.references[2];
            this.splitSource = source.Split(",");
        }
        else if (choice == "4") {
            this.content = this.scriptures[3];
            this.source = this.references[3];
            this.splitSource = source.Split(",");
        }
        else if (choice == "5") {
            this.content = this.scriptures[4];
            this.source = this.references[4];
            this.splitSource = source.Split(",");
        }
        else {
            Console.WriteLine("The item do not exit!");
            Console.WriteLine("Please restart again.");
        }
        
        int length = splitSource.Length;

        if (length == 3) {
            scripture = new Scripture (new Reference(splitSource[0], int.Parse(splitSource[1]), int.Parse(splitSource[2])), content);
            scripture.Split(content);
        }
        else{
            scripture = new Scripture (new Reference(splitSource[0], int.Parse(splitSource[1]), int.Parse(splitSource[2]), int.Parse(splitSource[3])), content);
            scripture.Split(content);
        }
        
        Console.Clear();
        scripture.Display();
        Console.Write("\nPress enter to continue or type 'quit' to finish: ");
        string input = Console.ReadLine();

        while (input.ToLower() != "quit"){

            Console.Clear();
            scripture.Hide();
            scripture.Display();
            Console.Write("\nPress enter to continue or type 'quit' to finish: ");
            input = Console.ReadLine();

            if (scripture.AllWordsHidden())
            {
                Console.Clear();
                Console.WriteLine("\nAll words are hidden. Press Enter to return to mean.");
                Console.ReadLine();
                break;
            }
        }
    }


    public void LoadFile() {

        Console.Write("What is the filename? [Please do not include the file type] ");
        string filename = Console.ReadLine();
        string[] lines = System.IO.File.ReadAllLines($"{filename}.txt");

        foreach (string line in lines)
        {   
            string newLine = line.Replace("\"", "");
            string[] splitNewLine = newLine.Split("|");
            oldReferences.Add(splitNewLine[0]);
            scriptures.Add(splitNewLine[1]);
        }
    }

    public void MemorizeTest(){

        Console.Clear();
        Console.WriteLine("You have 30 seconds to review the scripture.");
        Console.Write("Which scripture do you want to take the test? ");
        scripture.Display();
    }
}