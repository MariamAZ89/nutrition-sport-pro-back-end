namespace NutriSportPro.API.Configuration;

public class FoodProgramConfiguration : IEntityTypeConfiguration<FoodProgram>
{
    public void Configure(EntityTypeBuilder<FoodProgram> builder)
    {
        builder.Property(f => f.Name)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(f => f.Description)
            .IsRequired()
            .HasMaxLength(500);
        builder.Property(f => f.GenerationAI)
            .IsRequired()
            .HasMaxLength(1000);

        builder.HasOne(f => f.User)
            .WithMany(u => u.FoodPrograms)
            .HasForeignKey(f => f.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.ToTable("FoodPrograms");
    }
}
