namespace Data.Configuration;

public class RoomFacilitiesConfiguration : IEntityTypeConfiguration<RoomFacilities>
{
    public void Configure(EntityTypeBuilder<RoomFacilities> builder)
    {
        builder.HasKey(x => new { x.FacilityId, x.RoomId });

        builder.HasData(
                       new RoomFacilities { FacilityId = 1, RoomId = 1 },
                       new RoomFacilities { FacilityId = 2, RoomId = 1 },
                       new RoomFacilities { FacilityId = 1, RoomId = 2 });

        builder.ToTable(nameof(RoomFacilities));
    }
}
