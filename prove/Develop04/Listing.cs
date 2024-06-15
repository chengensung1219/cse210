using System;
using System.Threading;
using Microsoft.Win32.SafeHandles;

class Listing : Activity {
    private List<Prompt> prompts = new List<Prompt>();
    private List<string> listingPrompts = new List<string> {
        "List as many people in your life who support and care for you",
        "List activities that make you feel healthy and energized.",
        "When have you felt th Holy Ghost this month?",
        "What kind of thing that you accomplish today?",
        "What has God helped you with this week?",
        "what happy memories did you have this week?",
        "What do you like to do in your free time?",
        "What delicious food have you eaten this week?",
        "Name qualities or skills you want to develop further.",
        "List things you're grateful for today, big or small.",
    };
    private List<string> inputHistroy = new List<string>();

    private List<string> history = new List<string>();
    public override async void Run()
    {   
        SetPrompts(listingPrompts);

        history.Clear();
        Console.WriteLine("Welcome to Listing Activity.\n");

        int totalSeconds = DisplayDescription();

        this.Loading();
        ListingProcess(totalSeconds);
        inputHistroy.Add(" ");
        Console.Write("Do you want to save your Listing Activity to a file? (Y/N) ");
        string answer = Console.ReadLine();
        if (answer.ToLower() == "y" || answer.ToLower() == "yes") {
            Console.Write("What is the filename? [Not include the file type (ex. txt)] ");
            string filename = Console.ReadLine();
            SaveFile(filename, inputHistroy);
        } 
        else if (answer.ToLower() == "n" || answer.ToLower() == "no") {
            inputHistroy.Clear();
        }
        
        Console.Write("\nPress <Enter> to start a new reflecting topic or type 'quit' to reture to menu: ");
        string input = Console.ReadLine();

        while (input.ToLower() != "quit")
        {
            Console.Clear();
            this.Loading();
            ListingProcess(totalSeconds);
            Console.Write("Do you want to save your Listing Activity to a file? (Y/N) ");
            answer = Console.ReadLine();
            if (answer.ToLower() == "y" || answer.ToLower() == "yes") {
                Console.Write("What is the filename? [Not include the file type (ex. txt)] ");
                string filename = Console.ReadLine();
                SaveFile(filename, inputHistroy);
            } 
            else if (answer.ToLower() == "n" || answer.ToLower() == "no") {
                inputHistroy.Clear();
                return;
        }
            
            Console.Write("\nPress <Enter> to start a new reflecting topic or type 'quit' to reture to menu: ");
            input = Console.ReadLine();

            if (AllPromptsUsed())
            {
                Console.Clear();
                Console.Write("All topics are used. Press <Enter> to return to mean.");
                input = Console.ReadLine();
                break;
            }
        }
    }
    public override int DisplayDescription()
    {
        Console.WriteLine("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.\n");

        Console.Write("How long, in seconds, would you like for your session? ");
        int second = int.Parse(Console.ReadLine());

        Console.Clear();
        return second;
    }
    public override void Countdown(string script, int seconds){
        for (int i = seconds; i > 0; i--)
        {
            Console.Clear();
            foreach (string line in history) {
                Console.WriteLine(line);
            }
            Console.WriteLine($"{script}{i}");
            Thread.Sleep(1000);
        }
        Console.Clear();
        history.Add("You may begin in:");
        foreach (string line in history) {
            Console.WriteLine(line);
        }
    }
    public string RandomListingPrompts(){

        Random random = new Random();
        int count = 0;
        int randomIndex = 0;
        while (count < 1){
            int totalItem = prompts.Count;
            randomIndex = random.Next(0, totalItem);
            if (prompts[randomIndex].GetUsed() == false){
                prompts[randomIndex].Used();
                count += 1;
                inputHistroy.Add($"Prompt: {prompts[randomIndex].GetPrompt()}");
            }
        }
        return prompts[randomIndex].GetPrompt();
    }
    public void SetPrompts(List<string> listingPrompts) {
        foreach (string item in listingPrompts){
            Prompt prompt = new Prompt(item);
            prompts.Add(prompt);
        }
    }
    public void LimitedInput(int totalSeconds){
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(totalSeconds);

        DateTime currentTime = DateTime.Now;
        int i = 0;
        while(currentTime < futureTime){
            Console.Write("> ");
            string answer = Console.ReadLine();
            inputHistroy.Add(answer);
            i += 1;
            currentTime = DateTime.Now;
        }
        Console.WriteLine($"You listed {i} items!\n");

    }
    public void ListingProcess(int totalSeconds){
        Console.WriteLine("Get ready...\n\n");
        history.Add("Get ready...\n\n");
        Console.WriteLine("List as many respondes you can to the following prompt:");
        history.Add("List as many respondes you can to the following prompt:");
        string prompt = RandomListingPrompts();
        Console.WriteLine($" --- {prompt} --- \n");
        history.Add($" --- {prompt} --- \n");
        Console.Write("When you ready, press <Enter> to continue.\n");
        string continuing = Console.ReadLine();
        history.Add("When you ready, press <Enter> to continue.\n");
        Countdown("You may begin in: ", 5);
        LimitedInput(totalSeconds);
        Console.WriteLine($"You have completed {totalSeconds} seconds of the Listing Activity.");
        Spinner(5);
    }
    public bool AllPromptsUsed()
    {
        return prompts.All(prompt => prompt.GetUsed());
    }
    public void Spinner(int seconds = 3, int speed = 200){

        string[] spinner = { "|", "/", "-", "\\" };
        int runTime = seconds * 1000;
        while (runTime > 0) {
            for (int i = 0; i < 3; i++) {
                Console.Write(spinner[i]);
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                System.Threading.Thread.Sleep(speed);
                runTime -= speed;
                Console.Write(" ");
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
            }
        }
    }
    public void SaveFile(string name, List<string> inputHistroy){
        string filename = $"{name}.txt";

        if (File.Exists(filename)) {
            Console.WriteLine("The file is already exist. The file will be replace.");
            Console.Write("Are you sure you still want to save the file as this file name? (Y/N) ");
            string answer = Console.ReadLine();

            if (answer.ToLower() == "y" || answer.ToLower() == "yes") {

                WriteToTXTorCSVFile(filename, inputHistroy);
            }
            else if (answer.ToLower() == "n" || answer.ToLower() == "no") {
                Console.WriteLine("Please enter the file name let you want to save again.");
                Console.Write("What is the filename? [Not include the file type (txt, csv, json...etc)] ");
                name = Console.ReadLine();

                filename = $"{name}.txt";
                WriteToTXTorCSVFile(filename, inputHistroy);
            }

        }
        else{
            WriteToTXTorCSVFile(filename, inputHistroy);
        }
    }
    public void WriteToTXTorCSVFile(string filename, List<string> inputHistroy)
    {
        using (StreamWriter saveFile = new StreamWriter(filename))
        {   
            foreach (string line in inputHistroy) {
            saveFile.WriteLine($"\"{line}\"");
            }
        }
        Console.WriteLine($"File {filename} has been saved successfully.\n");
    }
}