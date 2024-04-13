using QuizMastery.DataAccess.Entities;
using QuizMastery.DataAccess.Repository.IRepository;

namespace QuizMastery.Business.Services.QuizService;

public interface IQuizService : IBaseRepository<Quiz>
{
    Task<object> GetQuizComponentsTree(Quiz quiz);
    Task RemoveQuestionsAndAnswersOnCascade(Quiz quiz);
}
