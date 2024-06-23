using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SmartHome
{
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

    public class House
    {
        private List<Room> rooms;

        public House()
        {
            rooms = new List<Room>();
        }

        public void AddRoom(Room room)
        {
            rooms.Add(room);
        }

        public Room GetRoom(string roomName)
        {
            return rooms.FirstOrDefault(r => r.Name == roomName);
        }
    }

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
}