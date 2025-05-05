namespace NutriSportPro.API.Configuration;

public class DietaryRecommendationConfiguration : IEntityTypeConfiguration<DietaryRecommendation>
{
    public void Configure(EntityTypeBuilder<DietaryRecommendation> builder)
    {
        builder.Property(d => d.Text)
            .IsRequired()
            .HasMaxLength(500);

        builder.HasOne(d => d.User)
            .WithMany(u => u.DietaryRecommendations)
            .HasForeignKey(d => d.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.ToTable("DietaryRecommendations");
    }
}