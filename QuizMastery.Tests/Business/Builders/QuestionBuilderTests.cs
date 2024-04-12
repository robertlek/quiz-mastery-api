using QuizMastery.Business.Builders.IBuilders;
using QuizMastery.Business.Builders;
using QuizMastery.DataAccess.Entities;

namespace QuizMastery.Tests.Business.Builders;

[TestFixture]
public class QuestionBuilderTests
{
    [Test]
    public void Build_Returns_Question_Instance()
    {
        var builder = new QuestionBuilder();

        Question question = builder.Build();

        Assert.That(question, Is.Not.Null);
        Assert.That(question, Is.InstanceOf<Question>());
    }

    [Test]
    public void Build_Returns_Question_Instance_With_Properties_Set()
    {
        var builder = new QuestionBuilder();
        var expectedId = Guid.NewGuid();
        var expectedMessage = "Question?";
        var expectedQuizId = Guid.NewGuid();
        var expectedScore = 10;

        Question question = builder.WithId(expectedId)
            .WithMessage(expectedMessage)
            .WithQuizId(expectedQuizId)
            .WithScore(expectedScore)
            .Build();

        Assert.Multiple(() =>
        {
            Assert.That(expectedId, Is.EqualTo(question.Id));
            Assert.That(expectedMessage, Is.EqualTo(question.Message));
            Assert.That(expectedQuizId, Is.EqualTo(question.QuizId));
            Assert.That(expectedScore, Is.EqualTo(question.Score));
        });
    }

    [Test]
    public void WithId_Sets_Id_Property_And_Returns_This()
    {
        var builder = new QuestionBuilder();
        var expectedId = Guid.NewGuid();

        IQuestionBuilder returnedBuilder = builder.WithId(expectedId);

        Assert.Multiple(() =>
        {
            Assert.That(expectedId, Is.EqualTo(builder.Build().Id));
            Assert.That(builder, Is.SameAs(returnedBuilder));
        });
    }

    [Test]
    public void WithMessage_Sets_Message_Property_And_Returns_This()
    {
        var builder = new QuestionBuilder();
        var expectedMessage = "Question?";

        IQuestionBuilder returnedBuilder = builder.WithMessage(expectedMessage);

        Assert.Multiple(() =>
        {
            Assert.That(expectedMessage, Is.EqualTo(builder.Build().Message));
            Assert.That(builder, Is.SameAs(returnedBuilder));
        });
    }

    [Test]
    public void WithQuizId_Sets_QuizId_Property_And_Returns_This()
    {
        var builder = new QuestionBuilder();
        var expectedQuizId = Guid.NewGuid();

        IQuestionBuilder returnedBuilder = builder.WithQuizId(expectedQuizId);

        Assert.Multiple(() =>
        {
            Assert.That(expectedQuizId, Is.EqualTo(builder.Build().QuizId));
            Assert.That(builder, Is.SameAs(returnedBuilder));
        });
    }

    [Test]
    public void WithScore_Sets_Score_Property_And_Returns_This()
    {
        var builder = new QuestionBuilder();
        var expectedScore = 10;

        IQuestionBuilder returnedBuilder = builder.WithScore(expectedScore);

        Assert.Multiple(() =>
        {
            Assert.That(expectedScore, Is.EqualTo(builder.Build().Score));
            Assert.That(builder, Is.SameAs(returnedBuilder));
        });
    }
}
