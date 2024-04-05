using QuizMastery.DataAccess.Context;
using QuizMastery.DataAccess.Entities;
using QuizMastery.DataAccess.Repository;

namespace QuizMastery.Business.Services.AnswerService;

public class AnswerService(BaseContext db) : BaseRepositoy<Answer>(db), IAnswerService
{
    private readonly BaseContext _db = db;
}
