using System;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        Running running = new Running("22 July 2024", 30, 4.8);
        activities.Add(running);
        Cycling cycling = new Cycling("22 July 2024", 20, 25);
        activities.Add(cycling);
        Swimming swimming = new Swimming("22 July 2024", 15, 25);
        activities.Add(swimming);

        Console.Clear();
        for (int i = 0; i < activities.Count; i++){
            
            Activity activity = activities[i];
            Console.WriteLine($"{activity.GetSummary()}\n");
        }
    }
}