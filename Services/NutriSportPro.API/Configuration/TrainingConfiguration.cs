namespace NutriSportPro.API.Configuration;

public class TrainingConfiguration : IEntityTypeConfiguration<Training>
{
    public void Configure(EntityTypeBuilder<Training> builder)
    {
        builder.Property(t => t.Date)
            .IsRequired();
        builder.Property(t => t.Duration)
            .IsRequired();
        builder.Property(t => t.Notes)
            .HasMaxLength(500);
        builder.HasOne(t => t.User)
            .WithMany(u => u.Training)
            .HasForeignKey(t => t.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(t => t.Exercises)
            .WithOne(e => e.Training)
            .HasForeignKey(e => e.TrainingId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.ToTable("Trainings");
    }
}
