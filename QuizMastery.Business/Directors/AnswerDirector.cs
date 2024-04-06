using QuizMastery.Business.Builders;
using QuizMastery.Business.Models.Answer;
using QuizMastery.DataAccess.Entities;

namespace QuizMastery.Business.Directors;

public class AnswerDirector
{
    public static Answer BuildFromAdd(AddAnswerModel model)
    {
        var builder = new AnswerBuilder();

        return builder
            .WithQuestionId(model.QuestionId)
            .WithMessage(model.Message)
            .IsCorrect(model.IsCorrect)
            .IsImage(model.IsImage)
            .Build();
    }

    public static Answer BuildFromUpdate(AnswerModel model)
    {
        var builder = new AnswerBuilder();

        return builder
            .WithId(model.Id)
            .WithQuestionId(model.QuestionId)
            .WithMessage(model.Message)
            .IsCorrect(model.IsCorrect)
            .IsImage(model.IsImage)
            .Build();
    }
}
