namespace NutriSportPro.API.Configuration;

public class SportsProfileConfiguration : IEntityTypeConfiguration<SportsProfile>
{
    public void Configure(EntityTypeBuilder<SportsProfile> builder)
    {
        builder.Property(sp => sp.Weight)
            .IsRequired();
        builder.Property(sp => sp.Height)
            .IsRequired();
        builder.Property(sp => sp.Goals)
            .HasMaxLength(500);
        builder.Property(sp => sp.Level)
            .IsRequired();
        builder.HasOne(sp => sp.User)
            .WithMany(u => u.SportsProfiles)
            .HasForeignKey(sp => sp.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.ToTable("SportsProfiles");
    }
}
