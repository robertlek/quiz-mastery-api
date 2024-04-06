using QuizMastery.Business.Builders;
using QuizMastery.Business.Models.Question;
using QuizMastery.DataAccess.Entities;

namespace QuizMastery.Business.Directors;

public class QuestionDirector
{
    public static Question BuildFromAdd(AddQuestionModel model)
    {
        var builder = new QuestionBuilder();

        return builder
            .WithQuizId(model.QuizId)
            .WithMessage(model.Message)
            .WithScore(model.Score)
            .Build();
    }

    public static Question BuildFromUpdate(QuestionModel model)
    {
        var builder = new QuestionBuilder();

        return builder
            .WithId(model.Id)
            .WithQuizId(model.QuizId)
            .WithMessage(model.Message)
            .WithScore(model.Score)
            .Build();
    }
}
