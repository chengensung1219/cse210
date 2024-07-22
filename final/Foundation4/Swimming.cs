using System;

class Swimming : Activity{
    private double Laps { get; set; }
    public Swimming(string date, double duration, int laps) : base(date, duration){

        Laps = laps;
    }
    public override double GetDistance(){

        return Laps * 50 / 1000;
    }
    public override double GetSpeed(){

        return GetDistance() / Duration * 60;
    }
    public override double GetPace(){

        return 60 / GetSpeed();
    }
    
}