using System.ComponentModel.DataAnnotations;

namespace QuizMastery.Business.Models.Answer;

public class AddAnswerModel
{
    [Required]
    public Guid QuestionId { get; set; }
    [Required]
    public string Message { get; set; } = null!;
    public bool IsCorrect { get; set; }
    public bool IsImage { get; set; }
}
