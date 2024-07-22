using System;

class Lecture : Event
{
    private string _speaker { get; set; }
    private int _capacity { get; set; }

    public Lecture(string title, string description, string date, string time, Address address, string speaker, int capacity) : base(title, description, date, time, address){
        
        _speaker = speaker;
        _capacity = capacity;
    }

    public override void FullDescription(){

        Console.WriteLine("Full Description:");
        StandardDescription();
        Console.WriteLine($"Type: Lecture\nSpeaker: {_speaker}\nCapacity: {_capacity}\n");
    }

    public override void ShortDescription(){
        
        Console.WriteLine("Short Description:");
        Console.WriteLine($"Type: Lecture\nTitle: {Title}\nDate: {Date}\n");
    }
}