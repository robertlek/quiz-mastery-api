namespace QuizMastery.Business.Models;

public class AnswerModel
{
    public Guid Id { get; set; }
    public Guid QuestionId { get; set; }
    public string Message { get; set; } = null!;
    public bool IsCorrect { get; set; }
    public bool IsImage { get; set; }
}
