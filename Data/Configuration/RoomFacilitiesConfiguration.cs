namespace Data.Configuration;

public class RoomFacilitiesConfiguration : IEntityTypeConfiguration<RoomFacilities>
{
    public void Configure(EntityTypeBuilder<RoomFacilities> builder)
    {
        builder.HasKey(x => new { x.FacilityId, x.RoomId });

        builder.ToTable(nameof(RoomFacilities));
    }
}
