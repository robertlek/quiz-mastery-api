using System.ComponentModel.DataAnnotations;

namespace QuizMastery.Business.Models.QuizType;

public class QuizTypeModel
{
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; } = null!;
}
