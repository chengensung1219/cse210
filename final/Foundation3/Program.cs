using System;

class Program
{
    static void Main(string[] args)
    {
        List<Event> events = new List<Event>();
        Lecture lecture = new Lecture("General Conference", "A gathering of members of the Church of Jesus Christ of Latter-day Saints and church leaders will give speeches.", "2024-10-05", "10:00 AM", new Address("60 North Temple", "Salt Lake City", "Utah", "USA"), "President Russell M. Nelson", 21000);
        events.Add(lecture);
        Reception reception = new Reception("Wedding Reception", "An unforgettable celebration of love, laughter, and happily ever after.", "2024-09-09", "02:00 PM", new Address("650 S 1st W", "Rexburg", "Idaho", "USA"), "WeddingReception@gmail.com");
        events.Add(reception);
        Outdoor outdoor = new Outdoor("Ultra Japan", "Experience the electrifying energy and unforgettable beats at Ultra Japan, where the world's top DJs and music lovers unite for an epic festival of electronic dance music.", "2024-09-14", "03:00 PM", new Address("1 Chome-4 Daiba", "Minato City", "Tokyo", "Japan"), "Sunny");
        events.Add(outdoor);

        Console.Clear();
        for (int i = 0; i < events.Count; i++)
        {   
            
            Event activity = events[i];
            activity.StandardDescription();
            Console.WriteLine(" ");
            activity.FullDescription();
            activity.ShortDescription();

            Console.WriteLine(" ");
        }

    }
}