using QuizMastery.Business.Builders.IBuilders;
using QuizMastery.DataAccess.Entities;

namespace QuizMastery.Business.Builders;

public class AnswerBuilder : IAnswerBuilder
{
    private readonly Answer _answer;

    public AnswerBuilder()
    {
        _answer = new Answer();
    }

    public Answer Build()
    {
        return _answer;
    }

    public IAnswerBuilder IsCorrect(bool isCorrect)
    {
        _answer.IsCorrect = isCorrect;
        return this;
    }

    public IAnswerBuilder IsImage(bool isImage)
    {
        _answer.IsImage = isImage;
        return this;
    }

    public IAnswerBuilder WithId(Guid id)
    {
        _answer.Id = id;
        return this;
    }

    public IAnswerBuilder WithMessage(string message)
    {
        _answer.Message = message;
        return this;
    }

    public IAnswerBuilder WithQuestionId(Guid id)
    {
        _answer.QuestionId = id;
        return this;
    }
}
