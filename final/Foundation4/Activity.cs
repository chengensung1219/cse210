abstract class Activity{
    public string Date { get; private set;}
    public double Duration { get; private set;}
    public Activity(string date, double duration){

        Date = date;
        Duration = duration;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();
    public virtual string GetSummary(){

        return $"{Date} {this.GetType().Name} ({Duration} min): Distance: {Math.Round(GetDistance(), 2)} km, Speed: {Math.Round(GetSpeed(), 2)} kph, Pace: {Math.Round(GetPace(), 2)} min per km";
    }
}