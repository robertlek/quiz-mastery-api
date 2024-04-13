using QuizMastery.DataAccess.Entities;
using QuizMastery.DataAccess.Repository.IRepository;

namespace QuizMastery.Business.Services.AnswerService;

public interface IAnswerService : IBaseRepository<Answer>
{
    public Task RemoveAllAnswersByQuestionId(Guid id);
}
