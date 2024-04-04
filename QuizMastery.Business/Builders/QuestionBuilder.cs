using QuizMastery.Business.Builders.IBuilders;
using QuizMastery.DataAccess.Entities;

namespace QuizMastery.Business.Builders;

public class QuestionBuilder : IQuestionBuilder
{
    private readonly Question _question;

    public QuestionBuilder()
    {
        _question = new Question();
    }

    public Question Build()
    {
        return _question;
    }

    public IQuestionBuilder WithMessage(string message)
    {
        _question.Message = message;
        return this;
    }

    public IQuestionBuilder WithQuizId(Guid id)
    {
        _question.QuizId = id;
        return this;
    }

    public IQuestionBuilder WithScore(int score)
    {
        _question.Score = score;
        return this;
    }
}
