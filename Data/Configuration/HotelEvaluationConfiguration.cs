namespace Data.Configuration;

public class HotelEvaluationConfiguration : IEntityTypeConfiguration<HotelEvaluations>
{
    public void Configure(EntityTypeBuilder<HotelEvaluations> builder)
    {
        builder.HasKey(x => new { x.HotelId, x.UserId });

        builder.ToTable(nameof(HotelEvaluations), opt =>
        {
            opt.HasCheckConstraint("CK_HotelEvaluations_Rate", "Rate >= 0 AND Rate <= 5");
        });
    }
}

