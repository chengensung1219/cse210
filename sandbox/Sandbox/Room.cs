using System;
public class Room
{
    public string Name;
    private List<SmartDevice> devices;

    public Room(string name)
    {
        Name = name;
        devices = new List<SmartDevice>();
    }

    public void AddDevice(SmartDevice device)
    {
        devices.Add(device);
    }

    public void TurnOnAllLights()
    {
        foreach (var device in devices.OfType<SmartLight>())
        {
            device.TurnOn();
        }
    }

    public void TurnOffAllLights()
    {
        foreach (var device in devices.OfType<SmartLight>())
        {
            device.TurnOff();
        }
    }

    public void TurnOnDevice(string deviceName)
    {
        var device = devices.FirstOrDefault(d => d.Name == deviceName);
        device?.TurnOn();
    }

    public void TurnOffDevice(string deviceName)
    {
        var device = devices.FirstOrDefault(d => d.Name == deviceName);
        device?.TurnOff();
    }

    public void TurnOnAllDevices()
    {
        foreach (var device in devices)
        {
            device.TurnOn();
        }
    }

    public void TurnOffAllDevices()
    {
        foreach (var device in devices)
        {
            device.TurnOff();
        }
    }

    public void ReportAllItems()
    {
        foreach (var device in devices)
        {
            Console.WriteLine(device);
        }
    }

    public void ReportAllItemsOn()
    {
        foreach (var device in devices.Where(d => d.IsOn()))
        {
            Console.WriteLine(device);
        }
    }

    public void ReportItemOnLongest()
    {
        var longestOnDevice = devices.Where(d => d.IsOn()).OrderByDescending(d => d.GetTimeOn()).FirstOrDefault();
        if (longestOnDevice != null)
        {
            Console.WriteLine($"{longestOnDevice.Name} has been on for the longest: {longestOnDevice.GetTimeOn()}");
        }
    }
}