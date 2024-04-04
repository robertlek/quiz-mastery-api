using QuizMastery.Business.Builders;
using QuizMastery.Business.Models;
using QuizMastery.DataAccess.Entities;

namespace QuizMastery.Business.Directors;

public class AnswerDirector
{
    public static Answer Build(AnswerModel model)
    {
        var builder = new AnswerBuilder();

        return builder
            .WithQuestionId(model.QuestionId)
            .WithMessage(model.Message)
            .IsCorrect(model.IsCorrect)
            .IsImage(model.IsImage)
            .Build();
    }
}
