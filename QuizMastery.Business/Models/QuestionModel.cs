namespace QuizMastery.Business.Models;

public class QuestionModel
{
    public Guid Id { get; set; }
    public Guid QuizId { get; set; }
    public string Message { get; set; } = null!;
    public int Score { get; set; }
}
