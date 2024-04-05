using System.ComponentModel.DataAnnotations;

namespace QuizMastery.Business.Models.QuizType;

public class AddQuizTypeModel
{
    [Required]
    public string Name { get; set; } = null!;
}
