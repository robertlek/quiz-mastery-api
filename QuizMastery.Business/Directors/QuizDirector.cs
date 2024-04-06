using QuizMastery.Business.Builders;
using QuizMastery.Business.Models.Quiz;
using QuizMastery.DataAccess.Entities;

namespace QuizMastery.Business.Directors;

public class QuizDirector
{
    public static Quiz BuildFromAdd(AddQuizModel model)
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

    public static Quiz BuildFromUpdate(QuizModel model, Quiz currentQuiz)
    {
        var builder = new QuizBuilder();

        Quiz quiz = builder
            .WithQuizTypeId(model.QuizTypeId)
            .WithName(model.Name)
            .WithDescription(model.Description)
            .WithMaxScore(model.MaxScore)
            .WithImageUrl(model.ImageUrl)
            .Build();

        return UpdateAdditionalProperties(currentQuiz, quiz);
    }

    private static Quiz AssignAditionalProperties(Quiz quiz)
    {
        quiz.IsActive = true;
        quiz.CreatedDate = DateTime.Now;

        return quiz;
    }

    private static Quiz UpdateAdditionalProperties(Quiz oldQuiz, Quiz newQuiz)
    {
        newQuiz.Id = oldQuiz.Id;
        newQuiz.IsActive = oldQuiz.IsActive;
        newQuiz.CreatedDate = oldQuiz.CreatedDate;

        return newQuiz;
    }
}
