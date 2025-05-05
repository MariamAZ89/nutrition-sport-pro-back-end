namespace NutriSportPro.API.Configuration;

public class CoachProfileConfiguration : IEntityTypeConfiguration<CoachProfile>
{
    public void Configure(EntityTypeBuilder<CoachProfile> builder)
    {
        builder.Property(c => c.Certification)
            .IsRequired();

        builder.HasOne(c => c.User)
            .WithOne(u => u.CoachProfile)
            .HasForeignKey<CoachProfile>(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.ToTable("CoachProfiles");
    }
}