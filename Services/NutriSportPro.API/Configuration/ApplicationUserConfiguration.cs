namespace NutriSportPro.API.Configuration;

public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.Property(u => u.FirstName)
            .IsRequired()
            .HasMaxLength(50);
        builder.Property(u => u.LastName)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasMany(u => u.SportsProfiles)
            .WithOne(sp => sp.User)
            .HasForeignKey(sp => sp.UserId);

        builder.HasMany(u => u.Training)
            .WithOne(t => t.User)
            .HasForeignKey(t => t.UserId);

        builder.HasMany(u => u.DietaryRecommendations)
            .WithOne(dr => dr.User)
            .HasForeignKey(dr => dr.UserId);

        builder.HasMany(u => u.TrainingPlans)
            .WithOne(tp => tp.User)
            .HasForeignKey(tp => tp.UserId);

        builder.HasMany(u => u.Nutritions)
            .WithOne(n => n.User)
            .HasForeignKey(n => n.UserId);

        builder.HasMany(u => u.Statistics)
            .WithOne(s => s.User)
            .HasForeignKey(s => s.UserId);

        builder.HasMany(u => u.FoodPrograms)
            .WithOne(fp => fp.User)
            .HasForeignKey(fp => fp.UserId);

        builder.HasMany(u => u.SentMessages)
            .WithOne(cm => cm.Sender)
            .HasForeignKey(cm => cm.SenderId);

        builder.HasMany(u => u.ReceivedMessages)
            .WithOne(cm => cm.Receiver)
            .HasForeignKey(cm => cm.ReceiverId);
    }
}
