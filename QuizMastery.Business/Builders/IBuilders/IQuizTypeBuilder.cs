using QuizMastery.DataAccess.Entities;

namespace QuizMastery.Business.Builders.IBuilders;

public interface IQuizTypeBuilder
{
    IQuizTypeBuilder WithName(string name);
    QuizType Build();
}
