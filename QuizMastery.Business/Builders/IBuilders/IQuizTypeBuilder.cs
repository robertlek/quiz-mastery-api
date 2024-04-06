using QuizMastery.DataAccess.Entities;

namespace QuizMastery.Business.Builders.IBuilders;

public interface IQuizTypeBuilder
{
    IQuizTypeBuilder WithId(Guid id);
    IQuizTypeBuilder WithName(string name);
    QuizType Build();
}
