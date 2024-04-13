using Microsoft.EntityFrameworkCore;
using QuizMastery.DataAccess.Context;
using QuizMastery.DataAccess.Entities;
using QuizMastery.DataAccess.Repository;

namespace QuizMastery.Business.Services.QuestionService;

public class QuestionService(BaseContext db) : BaseRepository<Question>(db), IQuestionService
{
    private readonly BaseContext _db = db;

    public async Task RemoveAllQuestionsByQuizId(Guid id)
    {
        Quiz? quiz = await _db.Quizzes.FirstOrDefaultAsync(x => x.Id == id);

        if (quiz != null)
        {
            _db.Questions.RemoveRange(_db.Questions.Where(x => x.QuizId == id));
            await _db.SaveChangesAsync();
        }
    }
}
