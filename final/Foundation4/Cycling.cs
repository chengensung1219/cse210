using System;

class Cycling : Activity{
    private double Speed { get; set; }
    public Cycling(string date, double duration, double speed) : base(date, duration){

        Speed = speed;
    }
    public override double GetDistance(){

        double hours = Duration / 60;
        return Speed * hours;
    }
    public override double GetSpeed(){

        return Speed;
    }
    public override double GetPace(){

        return 60 / Speed;
    }
    
}