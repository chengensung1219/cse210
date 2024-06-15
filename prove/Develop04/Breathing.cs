using System;
using System.Net.Mime;

class Breathing : Activity
{
    List<string> history = new List<string>();
    public override void Run()
    {
        history.Clear();

        Console.WriteLine("Welcome to Breathing Activity.\n");

        int totalSeconds = DisplayDescription();

        this.Loading();

        Console.WriteLine("Get ready...\n\n");
        history.Add("Get ready...\n\n");
        
        int times = totalSeconds / 10;
        int remainder = totalSeconds % 10;
        float remainderBreatheIn = (remainder / 10.0f) * 4;
        float remainderBreatheOut = (remainder / 10.0f) * 6;
        int roundRBI = (int) Math.Round(remainderBreatheIn);
        int roundRBO = (int) Math.Round(remainderBreatheOut);

        if (totalSeconds % 10 > 1){
            Countdown("Breathe in ...", roundRBI);
            Countdown("Now breathe out...", roundRBO);
            history.Add(" ");
        }

        for (int i = times; i > 0; i--){
            Countdown("Breathe in ...", 4);
            Countdown("Now breathe out...", 6);
            history.Add(" ");
        }
        Console.Clear();
        foreach (string line in history) {
            Console.WriteLine(line);
        }
        Console.WriteLine("Well done!!!\n");
        Console.WriteLine("You have completed another 30 seconds of the Breathing Activity\n");
        Console.Write("Press <Enter> to back to menu: ");
        string input = Console.ReadLine();
        Console.Clear();
    }

    public override int DisplayDescription()
    {
        Console.WriteLine("This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.\n");

        Console.Write("How long, in seconds, would you like for your session? ");
        int seconds = int.Parse(Console.ReadLine());
        
        Console.Clear();
        return seconds;
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
        history.Add(script);
    }
}