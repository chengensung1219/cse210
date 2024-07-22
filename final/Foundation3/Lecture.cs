using System;

class Lecture : Event
{
    private string Speaker { get; set; }
    private int Capacity { get; set; }

    public Lecture(string title, string description, string date, string time, Address address, string speaker, int capacity) : base(title, description, date, time, address){
        
        Speaker = speaker;
        Capacity = capacity;
    }

    public override void FullDescription(){

        Console.WriteLine("Full Description:");
        StandardDescription();
        Console.WriteLine($"Type: Lecture\nSpeaker: {Speaker}\nCapacity: {Capacity}\n");
    }

    public override void ShortDescription(){
        
        Console.WriteLine("Short Description:");
        Console.WriteLine($"Type: Lecture\nTitle: {Title}\nDate: {Date}\n");
    }
}