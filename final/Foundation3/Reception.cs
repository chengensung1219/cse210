using System;

class Reception : Event
{
    private string _rsvpEmail { get; set; }

    public Reception(string title, string description, string date, string time, Address address, string rsvpEmail) : base(title, description, date, time, address){

        _rsvpEmail = rsvpEmail;
    }

    public override void FullDescription(){

        Console.WriteLine("Full Description:");
        StandardDescription();
        Console.WriteLine($"Type: Reception\nRSVP Email: {_rsvpEmail}\n");
    }

    public override void ShortDescription(){

        Console.WriteLine("Short Description:");
        Console.WriteLine($"Type: Reception\nTitle: {Title}\nDate: {Date}\n");
    }
}