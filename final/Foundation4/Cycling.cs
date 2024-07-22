using System;

class Cycling : Activity{
    private double _speed { get; set; }
    public Cycling(string date, double duration, double speed) : base(date, duration){

        _speed = speed;
    }
    public override double GetDistance(){

        double hours = Duration / 60;
        return _speed * hours;
    }
    public override double GetSpeed(){

        return _speed;
    }
    public override double GetPace(){

        return 60 / _speed;
    }
    
}