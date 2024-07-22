abstract class Event
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public string Date { get; private set; }
    public string Time { get; private set; }
    public Address Address { get; private set; }

    public Event(string title, string description, string date, string time, Address address)
    {
        Title = title;
        Description = description;
        Date = date;
        Time = time;
        Address = address;
    }

    public virtual void StandardDescription()
    {
        Console.WriteLine($"Title: {Title}\nDescription: {Description}\nDate: {Date} {Time}\nLocation: {Address}");
    }

    public abstract void FullDescription();

    public abstract void ShortDescription();
}