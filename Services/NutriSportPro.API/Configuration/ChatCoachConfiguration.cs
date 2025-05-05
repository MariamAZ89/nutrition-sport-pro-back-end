namespace NutriSportPro.API.Configuration;

public class ChatCoachConfiguration : IEntityTypeConfiguration<ChatCoach>
{
    public void Configure(EntityTypeBuilder<ChatCoach> builder)
    {
        builder.Property(c => c.Message)
            .IsRequired()
            .HasMaxLength(500);

        builder.HasOne(c => c.Sender)
            .WithMany(u => u.SentMessages)
            .HasForeignKey(c => c.SenderId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(c => c.Receiver)
            .WithMany(u => u.ReceivedMessages)
            .HasForeignKey(c => c.ReceiverId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.ToTable("ChatCoachs");
    }
}