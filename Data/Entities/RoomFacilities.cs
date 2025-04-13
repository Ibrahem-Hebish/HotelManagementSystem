namespace Data.Entities;

public class RoomFacilities
{
    public int RoomId { get; set; }
    [ForeignKey(nameof(RoomId))]
    public Room Room { get; set; }
    public int FacilityId { get; set; }
    [ForeignKey(nameof(FacilityId))]
    public Facilitiy Facilitiy { get; set; }
}
