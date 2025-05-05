namespace NutriSportPro.API.Configuration;

public class NutritionConfiguration : IEntityTypeConfiguration<Nutrition>
{
    public void Configure(EntityTypeBuilder<Nutrition> builder)
    {
        builder.Property(n => n.Calories)
            .IsRequired();
        builder.Property(n => n.Protein)
            .IsRequired();
        builder.Property(n => n.Carbohydrates)
            .IsRequired();
        builder.Property(n => n.Lipids)
            .IsRequired();
        builder.Property(n => n.Food)
            .HasMaxLength(100);
        builder.Property(n => n.Date)
            .IsRequired();
        builder.Property(n => n.Notes)
            .HasMaxLength(500);
        builder.HasOne(n => n.User)
            .WithMany(u => u.Nutritions)
            .HasForeignKey(n => n.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.ToTable("Nutritions");
    }
}
