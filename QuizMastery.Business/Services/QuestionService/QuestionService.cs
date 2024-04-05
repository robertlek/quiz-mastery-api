using QuizMastery.DataAccess.Context;
using QuizMastery.DataAccess.Entities;
using QuizMastery.DataAccess.Repository;

namespace QuizMastery.Business.Services.QuestionService;

public class QuestionService(BaseContext db) : BaseRepositoy<Question>(db), IQuestionService
{
    private readonly BaseContext _db = db;
}
