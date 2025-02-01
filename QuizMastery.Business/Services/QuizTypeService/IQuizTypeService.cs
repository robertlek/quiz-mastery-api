using QuizMastery.Business.Models.QuizType;
using QuizMastery.DataAccess.Entities;
using QuizMastery.DataAccess.Repository.IRepository;

namespace QuizMastery.Business.Services.QuizTypeService;

public interface IQuizTypeService : IBaseRepository<QuizType>
{
    Task<QuizTypeStatisticsModel> GetQuizTypeStatistics(Guid quizTypeId);
}
