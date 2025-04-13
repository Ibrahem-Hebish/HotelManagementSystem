namespace Data.Entities;

public class Facilitiy
{
    public int Id { get; set; }

    public string Name { get; set; }

    public List<Room> Rooms { get; set; } = [];

    public List<RoomFacilities> Facilities { get; set; } = [];
}
