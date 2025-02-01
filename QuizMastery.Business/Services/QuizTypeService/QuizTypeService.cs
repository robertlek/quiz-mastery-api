using Microsoft.EntityFrameworkCore;
using QuizMastery.Business.Models.QuizType;
using QuizMastery.DataAccess.Context;
using QuizMastery.DataAccess.Entities;
using QuizMastery.DataAccess.Repository;

namespace QuizMastery.Business.Services.QuizTypeService;

public class QuizTypeService(BaseContext db) : BaseRepository<QuizType>(db), IQuizTypeService
{
    private readonly BaseContext _db = db;

    public async Task<QuizTypeStatisticsModel> GetQuizTypeStatistics(Guid quizTypeId)
    {
        IEnumerable<Quiz> quizzes = await _db.Quizzes.Where(x => x.QuizTypeId == quizTypeId).ToListAsync();

        var questions = new List<Question>();
        var answers = new List<Answer>();

        foreach (var quiz in quizzes)
        {
            IEnumerable<Question> questionsInQuiz = await _db.Questions.Where(x => x.QuizId == quiz.Id).ToListAsync();

            questions.AddRange(questionsInQuiz);

            foreach (var question in questionsInQuiz)
            {
                answers.AddRange(await _db.Answers.Where(x => x.QuestionId == question.Id).ToListAsync());
            }
        }

        return new QuizTypeStatisticsModel
        {
            Quizzes = quizzes.Count(),
            Questions = questions.Count,
            Answers = answers.Count
        };
    }
}
