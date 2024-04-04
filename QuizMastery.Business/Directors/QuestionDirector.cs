using QuizMastery.Business.Builders;
using QuizMastery.Business.Models;
using QuizMastery.DataAccess.Entities;

namespace QuizMastery.Business.Directors;

public class QuestionDirector
{
    public static Question Build(QuestionModel model)
    {
        var builder = new QuestionBuilder();

        return builder
            .WithQuizId(model.QuizId)
            .WithMessage(model.Message)
            .WithScore(model.Score)
            .Build();
    }
}
