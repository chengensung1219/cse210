using System;

class Outdoor : Event
{
    private string Weather { get; set; }
    public Outdoor(string title, string description, string date, string time, Address address, string weather) : base(title, description, date, time, address){
        
        Weather = weather;
    }

    public override void FullDescription(){

        Console.WriteLine("Full Description:");
        StandardDescription();
        Console.WriteLine($"Type: Outdoor Gathering\nWeather: {Weather}\n");
    }

    public override void ShortDescription(){
        
        Console.WriteLine("Short Description:");
        Console.WriteLine($"Type: Outdoor Gathering\nTitle: {Title}\nDate: {Date}\n");
    }
}
