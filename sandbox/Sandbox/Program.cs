using System;

class Program
{
    static void Main(string[] args)
    {
        House house = new House();

        Room livingRoom = new Room("Living Room");
        livingRoom.AddDevice(new SmartLight("Living Room Light 1"));
        livingRoom.AddDevice(new SmartHeater("Living Room Heater"));
        livingRoom.AddDevice(new SmartTV("Living Room TV"));

        Room kitchen = new Room("Kitchen");
        kitchen.AddDevice(new SmartLight("Kitchen Light 1"));
        kitchen.AddDevice(new SmartLight("Kitchen Light 2"));

        house.AddRoom(livingRoom);
        house.AddRoom(kitchen);

        livingRoom.TurnOnDevice("Living Room Light 1");
        kitchen.TurnOnAllLights();

        Console.WriteLine("Report All Items in Living Room:");
        livingRoom.ReportAllItems();

        Console.WriteLine("\nReport All Items that are On in Kitchen:");
        kitchen.ReportAllItemsOn();

        Thread.Sleep(2000); // Wait for 2 seconds

        Console.WriteLine("\nItem that has been On the Longest in Kitchen:");
        kitchen.ReportItemOnLongest();
    }
}