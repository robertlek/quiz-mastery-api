using QuizMastery.DataAccess.Entities;

namespace QuizMastery.Business.Builders.IBuilders;

public interface IAnswerBuilder
{
    IAnswerBuilder WithQuestionId(Guid id);
    IAnswerBuilder WithMessage(string message);
    IAnswerBuilder IsCorrect(bool isCorrect);
    IAnswerBuilder IsImage(bool isImage);
    Answer Build();
}
