using Microsoft.EntityFrameworkCore;
using QuizMastery.DataAccess.Context;
using QuizMastery.DataAccess.Entities;
using QuizMastery.DataAccess.Repository;

namespace QuizMastery.Business.Services.AnswerService;

public class AnswerService(BaseContext db) : BaseRepository<Answer>(db), IAnswerService
{
    private readonly BaseContext _db = db;

    public async Task RemoveAllAnswersByQuestionId(Guid id)
    {
        Question? question = await _db.Questions.FirstOrDefaultAsync(x => x.Id == id);

        if (question != null)
        {
            _db.Answers.RemoveRange(_db.Answers.Where(x => x.QuestionId.Equals(question.Id)));
            await _db.SaveChangesAsync();
        }
    }
}
