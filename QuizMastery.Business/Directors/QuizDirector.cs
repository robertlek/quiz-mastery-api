using QuizMastery.Business.Builders;
using QuizMastery.Business.Models;
using QuizMastery.DataAccess.Entities;

namespace QuizMastery.Business.Directors;

public class QuizDirector
{
    public static Quiz Build(QuizModel model)
    {
        var builder = new QuizBuilder();

        Quiz quiz = builder
            .WithQuizTypeId(model.QuizTypeId)
            .WithName(model.Name)
            .WithDescription(model.Description)
            .WithMaxScore(model.MaxScore)
            .WithImageUrl(model.ImageUrl)
            .Build();

        return AssignAditionalProperties(quiz);
    }

    private static Quiz AssignAditionalProperties(Quiz quiz)
    {
        quiz.IsActive = true;
        quiz.CreatedDate = DateTime.Now;

        return quiz;
    }
}
