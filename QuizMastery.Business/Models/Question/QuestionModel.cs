using System.ComponentModel.DataAnnotations;

namespace QuizMastery.Business.Models.Question;

public class QuestionModel
{
    public Guid Id { get; set; }
    [Required]
    public Guid QuizId { get; set; }
    [Required]
    public string Message { get; set; } = null!;
    [Required]
    public int Score { get; set; }
}
