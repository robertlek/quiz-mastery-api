using QuizMastery.DataAccess.Entities;

namespace QuizMastery.Business.Builders.IBuilders;

public interface IQuizBuilder
{
    IQuizBuilder WithQuizTypeId(Guid id);
    IQuizBuilder WithName(string name);
    IQuizBuilder WithDescription(string? description);
    IQuizBuilder WithMaxScore(int maxScore);
    IQuizBuilder WithImageUrl(string? imageUrl);
    Quiz Build();
}
