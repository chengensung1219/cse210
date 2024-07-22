using System;

class Running : Activity{
    private double Distance { get; set; }
    public Running(string date, double duration, double distance) : base(date, duration){

        Distance = distance;
    }

    public override double GetDistance(){

        return this.Distance;
    }
    public override double GetSpeed(){

        double hours = Duration / 60;
        return Distance / hours;
    }
    public override double GetPace(){

        return Duration / GetDistance();
    }


}