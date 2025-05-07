namespace Data.Entities;

public class Facilitiy : IEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = "";

    public List<Room> Rooms { get; set; } = [];

    public List<RoomFacilities> RoomFacilities { get; set; } = [];
}
