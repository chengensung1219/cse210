using System;
public abstract class SmartDevice
{
    public string Name;
    private DateTime turnOnTime;
    private DateTime turnOffTime;
    private bool isOn;

    protected SmartDevice(string name)
    {
        Name = name;
        turnOnTime = DateTime.MinValue;
        turnOffTime = DateTime.MinValue;
        isOn = false;
    }

    public void TurnOn()
    {
        if (!isOn)
        {
            turnOnTime = DateTime.Now;
            isOn = true;
        }
    }

    public void TurnOff()
    {
        if (isOn)
        {
            turnOffTime = DateTime.Now;
            isOn = false;
        }
    }

    public bool IsOn()
    {
        return isOn;
    }

    public TimeSpan GetTimeOn()
    {
        if (isOn)
        {
            return DateTime.Now - turnOnTime;
        }
        return TimeSpan.Zero;
    }

    public override string ToString()
    {
        return $"{Name} is {(IsOn() ? "On" : "Off")}";
    }
}

public class SmartLight : SmartDevice
{
    public SmartLight(string name) : base(name) { }
}

public class SmartHeater : SmartDevice
{
    public SmartHeater(string name) : base(name) { }
}

public class SmartTV : SmartDevice
{
    public SmartTV(string name) : base(name) { }
}

