using QuizMastery.Business.Builders.IBuilders;
using QuizMastery.Business.Builders;
using QuizMastery.DataAccess.Entities;

namespace QuizMastery.Tests.Business.Builders;

[TestFixture]
public class AnswerBuilderTests
{
    [Test]
    public void Build_Returns_Answer_Instance()
    {
        var builder = new AnswerBuilder();

        Answer answer = builder.Build();

        Assert.That(answer, Is.Not.Null);
        Assert.That(answer, Is.InstanceOf<Answer>());
    }

    [Test]
    public void Build_Returns_Answer_Instance_With_Properties_Set()
    {
        var builder = new AnswerBuilder();
        var expectedIsCorrect = true;
        var expectedIsImage = true;
        var expectedId = Guid.NewGuid();
        var expectedMessage = "Anwer";
        var expectedQuestionId = Guid.NewGuid();

        Answer answer = builder.IsCorrect(expectedIsCorrect)
            .IsImage(expectedIsImage)
            .WithId(expectedId)
            .WithMessage(expectedMessage)
            .WithQuestionId(expectedQuestionId)
            .Build();

        Assert.Multiple(() =>
        {
            Assert.That(expectedIsCorrect, Is.EqualTo(answer.IsCorrect));
            Assert.That(expectedIsImage, Is.EqualTo(answer.IsImage));
            Assert.That(expectedId, Is.EqualTo(answer.Id));
            Assert.That(expectedMessage, Is.EqualTo(answer.Message));
            Assert.That(expectedQuestionId, Is.EqualTo(answer.QuestionId));
        });
    }

    [Test]
    public void IsCorrect_Sets_IsCorrect_Property_And_Returns_This()
    {
        var builder = new AnswerBuilder();
        var expectedIsCorrect = true;

        IAnswerBuilder returnedBuilder = builder.IsCorrect(expectedIsCorrect);

        Assert.Multiple(() =>
        {
            Assert.That(expectedIsCorrect, Is.EqualTo(builder.Build().IsCorrect));
            Assert.That(builder, Is.SameAs(returnedBuilder));
        });
    }

    [Test]
    public void IsImage_Sets_IsImage_Property_And_Returns_This()
    {
        var builder = new AnswerBuilder();
        var expectedIsImage = true;

        IAnswerBuilder returnedBuilder = builder.IsImage(expectedIsImage);

        Assert.Multiple(() =>
        {
            Assert.That(expectedIsImage, Is.EqualTo(builder.Build().IsImage));
            Assert.That(builder, Is.SameAs(returnedBuilder));
        });
    }

    [Test]
    public void WithId_Sets_Id_Property_And_Returns_This()
    {
        var builder = new AnswerBuilder();
        var expectedId = Guid.NewGuid();

        IAnswerBuilder returnedBuilder = builder.WithId(expectedId);

        Assert.Multiple(() =>
        {
            Assert.That(expectedId, Is.EqualTo(builder.Build().Id));
            Assert.That(builder, Is.SameAs(returnedBuilder));
        });
    }

    [Test]
    public void WithMessage_Sets_Message_Property_And_Returns_This()
    {
        var builder = new AnswerBuilder();
        var expectedMessage = "Answer";

        IAnswerBuilder returnedBuilder = builder.WithMessage(expectedMessage);

        Assert.Multiple(() =>
        {
            Assert.That(expectedMessage, Is.EqualTo(builder.Build().Message));
            Assert.That(builder, Is.SameAs(returnedBuilder));
        });
    }

    [Test]
    public void WithQuestionId_Sets_QuestionId_Property_And_Returns_This()
    {
        var builder = new AnswerBuilder();
        var expectedQuestionId = Guid.NewGuid();

        IAnswerBuilder returnedBuilder = builder.WithQuestionId(expectedQuestionId);

        Assert.Multiple(() =>
        {
            Assert.That(expectedQuestionId, Is.EqualTo(builder.Build().QuestionId));
            Assert.That(builder, Is.SameAs(returnedBuilder));
        });
    }
}
