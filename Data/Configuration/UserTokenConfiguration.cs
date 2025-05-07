namespace Data.Configuration;

public class UserTokenConfiguration : IEntityTypeConfiguration<UserToken>
{
    public void Configure(EntityTypeBuilder<UserToken> builder)
    {

        builder.HasOne(x => x.User)
            .WithMany(x => x.UserTokens)
            .HasForeignKey(x => x.Userid)
            .OnDelete(DeleteBehavior.Cascade);

        builder.ToTable(nameof(UserToken));
    }
}

