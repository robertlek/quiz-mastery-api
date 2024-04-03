using Microsoft.EntityFrameworkCore;
using QuizMastery.DataAccess.Entities;

namespace QuizMastery.DataAccess.Context;

public class BaseContext(DbContextOptions<BaseContext> options) : DbContext(options)
{
    public DbSet<QuizType> QuizTypes { get; set; }
    public DbSet<Quiz> Quizzes { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Answer> Answers { get; set; }
}
