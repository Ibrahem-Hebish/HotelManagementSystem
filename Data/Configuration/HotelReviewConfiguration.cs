namespace Data.Configuration;

public class HotelReviewConfiguration : IEntityTypeConfiguration<HotelReviews>
{
    public void Configure(EntityTypeBuilder<HotelReviews> builder)
    {
        builder.HasKey(x => new { x.HotelId, x.UserId });

        builder.ToTable(nameof(HotelReviews), opt =>
        {
            opt.HasCheckConstraint("CK_HotelReviews_Rate", "Rate >= 0 AND Rate <= 5");
        });
    }
}

