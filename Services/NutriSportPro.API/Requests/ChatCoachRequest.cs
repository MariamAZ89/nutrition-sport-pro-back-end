using System.ComponentModel.DataAnnotations;

namespace NutriSportPro.API.Requests;

public class ChatCoachRequest
{
    [Required]
    public string ReceiverId { get; set; } = null!;
    public string Message { get; set; } = null!;
    public DateTime SentAt { get; set; } = DateTime.UtcNow;
}
