using QuizMastery.Business.Builders.IBuilders;
using QuizMastery.DataAccess.Entities;

namespace QuizMastery.Business.Builders;

public class QuizTypeBuilder : IQuizTypeBuilder
{
    private readonly QuizType _quizType;

    public QuizTypeBuilder()
    {
        _quizType = new QuizType();
    }

    public QuizType Build()
    {
        return _quizType;
    }

    public IQuizTypeBuilder WithName(string name)
    {
        _quizType.Name = name;
        return this;
    }
}
