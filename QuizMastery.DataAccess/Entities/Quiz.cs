using System.ComponentModel.DataAnnotations;

namespace QuizMastery.DataAccess.Entities;

public class Quiz
{
    [Key]
    public Guid Id { get; set; }
    public Guid QuizTypeId { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public int MaxScore { get; set; }
    public string? ImageUrl { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedDate { get; set; }
}
