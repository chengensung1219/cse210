using System;
using System.Data.SqlTypes;

class Reflecting : Activity
{   
    private List<Topic> topics = new List<Topic>();
    private List<string> history = new List<string>();
    private List<string> reflectingTopics = new List<string> {
        "Reflect on a significant personal achievement in the past year.",
        "Think about a challenging situation you faced recently.",
        "Reflect on your core values and beliefs.",
        "Consider the important relationships in your life.",
        "Reflect on your career goals and progress.",
        "Think about how you manage your time.",
        "Reflect on your physical and mental health.",
        "Consider your recent learning experiences, whether formal or informal.",
        "Reflect on a creative project or idea you pursued.",
        "Think about your future goals and aspirations.",
    };
    private List<string> followingQuestion1 = new List<string>(){
        "What steps did you take to achieve it?",
        "How did you handle it?",
        "Can you recall a situation where your values were tested?",
        "How have these relationships evolved?",
        "What skills have you developed?",
        "What strategies have worked well for you?",
        "What practices have you adopted to maintain your well-being?",
        "What new knowledge or skills have you acquired?",
        "What inspired you?",
        "How have your priorities changed?",
    };
    private List<string> followingQuestion2 = new List<string>(){
        "How did it impact your personal growth?",
        "what did you learn about yourself through this experience?",
        "How did you respond?",
        "What have you learned about communication and connection?",
        "What areas do you need to focus on for future growth?",
        "Where do you see room for improvement?",
        "What changes might you need to make?",
        "How have they impacted your perspective?",
        "What did you learn through the creative process?",
        "what steps will you take to achieve these goals?",
    };

    public override void Run()
    {   
        SetTopic(reflectingTopics);
        Console.WriteLine("Welcome to Reflecting Activity.\n");

        int totalSeconds = DisplayDescription();

        this.Loading();
        int randomIndex = RandomReflectingTopics();
        string topic = topics[randomIndex].GetTopic();
        ReflectingProcess(topic, followingQuestion1[randomIndex], followingQuestion2[randomIndex], totalSeconds);
        Console.WriteLine($"You just completed another {totalSeconds} seconds of the Reflecting Activity.");

        Console.Write("\nPress <Enter> to start a new reflecting topic or type 'quit' to reture to menu: ");
        string input = Console.ReadLine();

        while (input.ToLower() != "quit")
        {
            Console.Clear();
            this.Loading();

            randomIndex = RandomReflectingTopics();
            topic = topics[randomIndex].GetTopic();
            ReflectingProcess(topic, followingQuestion1[randomIndex], followingQuestion2[randomIndex], totalSeconds);
            Console.WriteLine($"You just completed another {totalSeconds} seconds of the Reflecting Activity.");
            
            Console.Write("\nPress <Enter> to start a new reflecting topic or type 'quit' to reture to menu: ");
            input = Console.ReadLine();

            if (AllTopicsUsed())
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
        Console.WriteLine("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.\n");

        Console.Write("How long, in seconds, would you like for your session? ");
        int second = int.Parse(Console.ReadLine());

        Console.Clear();
        return second;
    }


    public int RandomReflectingTopics(){

        Random random = new Random();
        int count = 0;
        int randomIndex = 0;
        while (count < 1){
            int totalItem = topics.Count;
            randomIndex = random.Next(0, totalItem);
            if (topics[randomIndex].GetUsed() == false){
                topics[randomIndex].Used();
                count += 1;
            }
        }
        return randomIndex;
    }
    public void SetTopic(List<string> reflectingTopics) {
        foreach (string item in reflectingTopics){
            Topic topic = new Topic(item);
            topics.Add(topic);
        }
    }
    public bool AllTopicsUsed()
    {
        return topics.All(topic => topic.GetUsed());
    }
    public void ReflectingProcess(string topic, string question1, string question2, int totalSeconds){
        history.Clear();
        Console.WriteLine("Get ready...\n\n");
        history.Add("Get ready...\n\n");
        Console.WriteLine("Consider the following prompt:\n");
        history.Add("Consider the following prompt:\n");
        Console.WriteLine($" --- {topic} --- \n");
        history.Add($" --- {topic} --- \n");
        Console.Write("When you have something in mind, press <Enter> to continue.\n");
        string continuing = Console.ReadLine();
        history.Add("When you have something in mind, press <Enter> to continue.\n");
        Console.WriteLine("Now ponder on each of following questions as they related to this experience.");
        history.Add("Now ponder on each of following questions as they related to this experience.");
        Countdown("You may begin in: ", 5);
        Console.Clear();
        Console.Write($"> {question1} ");
        Spinner(totalSeconds / 2);
        Console.WriteLine(" ");
        Console.Write($"> {question2} ");
        Spinner(totalSeconds / 2);
        Console.WriteLine("\n\nWell done!!!\n");
    }
    public override void Countdown(string script, int seconds) {
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
}