namespace NutriSportPro.API.Configuration;

public class StatisticConfiguration : IEntityTypeConfiguration<Statistic>
{
    public void Configure(EntityTypeBuilder<Statistic> builder)
    {
        builder.Property(s => s.Weight)
            .IsRequired();
        builder.Property(s => s.MuscleMass)
            .IsRequired();
        builder.Property(s => s.FatMass)
            .IsRequired();
        builder.Property(s => s.HeartRate)
            .IsRequired();
        builder.Property(s => s.Date)
            .IsRequired();
        builder.Property(s => s.Notes)
            .HasMaxLength(500);
        builder.HasOne(s => s.User)
            .WithMany(u => u.Statistics)
            .HasForeignKey(s => s.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.ToTable("Statistics");
    }
}   