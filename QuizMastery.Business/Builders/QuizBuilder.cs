using QuizMastery.Business.Builders.IBuilders;
using QuizMastery.DataAccess.Entities;

namespace QuizMastery.Business.Builders;

public class QuizBuilder : IQuizBuilder
{
    private readonly Quiz _quiz;

    public QuizBuilder()
    {
        _quiz = new Quiz();
    }

    public Quiz Build()
    {
        return _quiz;
    }

    public IQuizBuilder WithDescription(string? description)
    {
        _quiz.Description = description;
        return this;
    }

    public IQuizBuilder WithImageUrl(string? imageUrl)
    {
        _quiz.ImageUrl = imageUrl;
        return this;
    }

    public IQuizBuilder WithMaxScore(int maxScore)
    {
        _quiz.MaxScore = maxScore;
        return this;
    }

    public IQuizBuilder WithName(string name)
    {
        _quiz.Name = name;
        return this;
    }

    public IQuizBuilder WithQuizTypeId(Guid id)
    {
        _quiz.QuizTypeId = id;
        return this;
    }
}
