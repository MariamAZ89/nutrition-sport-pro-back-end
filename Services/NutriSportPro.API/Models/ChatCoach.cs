namespace NutriSportPro.API.Models;

public class ChatCoach
{
    public int Id { get; set; }
    public string SenderId { get; set; } = null!;
    public ApplicationUser? Sender { get; set; }
    public string ReceiverId { get; set; } = null!;
    public ApplicationUser? Receiver { get; set; }
    public string Message { get; set; } = null!;
    public DateTime SentAt { get; set; } = DateTime.UtcNow;
}
