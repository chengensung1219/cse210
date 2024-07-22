using System;

class Swimming : Activity{
    private double _laps { get; set; }
    public Swimming(string date, double duration, int laps) : base(date, duration){

        _laps = laps;
    }
    public override double GetDistance(){

        return _laps * 50 / 1000;
    }
    public override double GetSpeed(){

        return GetDistance() / Duration * 60;
    }
    public override double GetPace(){

        return 60 / GetSpeed();
    }
    
}