using QuizMastery.Business.Builders;
using QuizMastery.Business.Models.QuizType;
using QuizMastery.DataAccess.Entities;

namespace QuizMastery.Business.Directors;

public class QuizTypeDirector
{
    public static QuizType BuildFromAdd(AddQuizTypeModel quizType)
    {
        var builder = new QuizTypeBuilder();

        return builder.WithName(quizType.Name).Build();
    }
}
