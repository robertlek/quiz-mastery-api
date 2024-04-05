using QuizMastery.DataAccess.Entities;
using QuizMastery.DataAccess.Repository.IRepository;

namespace QuizMastery.Business.Services.QuestionService;

public interface IQuestionService : IBaseRepository<Question>
{
}
