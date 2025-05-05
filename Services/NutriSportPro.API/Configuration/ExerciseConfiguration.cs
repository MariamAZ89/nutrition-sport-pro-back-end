namespace NutriSportPro.API.Configuration;

public class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>
{
    public void Configure(EntityTypeBuilder<Exercise> builder)
    {
        builder.Property(e => e.Duration)
            .IsRequired();
        builder.Property(e => e.Repetitions)
            .IsRequired();
        builder.Property(e => e.Sets)
            .IsRequired();
        builder.Property(e => e.Weight)
            .IsRequired();
        builder.HasOne(e => e.Training)
            .WithMany(t => t.Exercises)
            .HasForeignKey(e => e.TrainingId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.ToTable("Exercises");
    }
}
