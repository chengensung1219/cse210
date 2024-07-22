using System;

class Running : Activity{
    private double _distance { get; set; }
    public Running(string date, double duration, double distance) : base(date, duration){

        _distance = distance;
    }

    public override double GetDistance(){

        return _distance;
    }
    public override double GetSpeed(){

        double hours = Duration / 60;
        return _distance / hours;
    }
    public override double GetPace(){

        return Duration / GetDistance();
    }


}