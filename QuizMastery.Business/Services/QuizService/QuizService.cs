using QuizMastery.DataAccess.Context;
using QuizMastery.DataAccess.Entities;
using QuizMastery.DataAccess.Repository;

namespace QuizMastery.Business.Services.QuizService;

public class QuizService(BaseContext db) : BaseRepositoy<Quiz>(db), IQuizService
{
    private readonly BaseContext _db = db;
}
