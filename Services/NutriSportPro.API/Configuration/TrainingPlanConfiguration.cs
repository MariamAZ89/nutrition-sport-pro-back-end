namespace NutriSportPro.API.Configuration;

public class TrainingPlanConfiguration: IEntityTypeConfiguration<TrainingPlan>
{
    public void Configure(EntityTypeBuilder<TrainingPlan> builder)
    {
        builder.Property(tp => tp.Name)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(tp => tp.Objective)
            .IsRequired()
            .HasMaxLength(500);
        builder.Property(tp => tp.Level)
            .IsRequired();
        builder.Property(tp => tp.DurationWeeks)
            .IsRequired();

        builder.HasOne(tp => tp.User)
            .WithMany(u => u.TrainingPlans)
            .HasForeignKey(tp => tp.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.ToTable("TrainingPlans");
    }
}

