using System;

class Outdoor : Event
{
    private string Weather { get; set; }
    public Outdoor(string title, string description, string date, string time, Address address, string weather) : base(title, description, date, time, address){
        
        Weather = weather;
    }

    public override void FullDescription(){

        StandardDescription();
        Console.WriteLine($"Type: Outdoor Gathering\nWeather: {Weather}\n");
    }

    public override void ShortDescription(){
        
        StandardDescription();
        Console.WriteLine($"Type: Outdoor Gathering\nTitle: {Title}\nDate: {Date}\n");
    }
}
