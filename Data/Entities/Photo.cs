namespace Data.Entities;

public class Photo : IEntity
{
    public int Id { get; set; }
    public string Path { get; set; } = "";
    public int RoomId { get; set; }
    [ForeignKey(nameof(RoomId))]
    public Room Room { get; set; }
}
