using System;
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