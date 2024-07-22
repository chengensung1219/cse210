using System;

class Reception : Event
{
    private string RSVPEmail { get; set; }

    public Reception(string title, string description, string date, string time, Address address, string rsvpEmail) : base(title, description, date, time, address){

        RSVPEmail = rsvpEmail;
    }

    public override void FullDescription(){

        Console.WriteLine("Full Description:");
        StandardDescription();
        Console.WriteLine($"Type: Reception\nRSVP Email: {RSVPEmail}\n");
    }

    public override void ShortDescription(){

        Console.WriteLine("Short Description:");
        Console.WriteLine($"Type: Reception\nTitle: {Title}\nDate: {Date}\n");
    }
}