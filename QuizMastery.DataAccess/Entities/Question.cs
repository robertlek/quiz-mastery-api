using System.ComponentModel.DataAnnotations;

namespace QuizMastery.DataAccess.Entities;

public class Question
{
    [Key]
    public Guid Id { get; set; }
    public Guid QuizId { get; set; }
    public string Message { get; set; } = null!;
    public int Score { get; set; }
}
