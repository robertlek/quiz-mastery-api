﻿using System.ComponentModel.DataAnnotations;

namespace QuizMastery.Business.Models.Quiz;

public class AddQuizModel
{
    [Required]
    public Guid QuizTypeId { get; set; }
    [Required]
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    [Required]
    public int MaxScore { get; set; }
    public string? ImageUrl { get; set; }
}
