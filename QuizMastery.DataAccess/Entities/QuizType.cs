using System.ComponentModel.DataAnnotations;

namespace QuizMastery.DataAccess.Entities;

public class QuizType
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
}
