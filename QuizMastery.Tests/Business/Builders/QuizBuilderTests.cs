using QuizMastery.Business.Builders;
using QuizMastery.Business.Builders.IBuilders;
using QuizMastery.DataAccess.Entities;

namespace QuizMastery.Tests.Business.Builders;

[TestFixture]
public class QuizBuilderTests
{
    [Test]
    public void Build_Returns_Quiz_Instance()
    {
        var builder = new QuizBuilder();

        Quiz quiz = builder.Build();

        Assert.That(quiz, Is.Not.Null);
        Assert.That(quiz, Is.InstanceOf<Quiz>());
    }

    [Test]
    public void Build_Returns_Quiz_Instance_With_Properties_Set()
    {
        var builder = new QuizBuilder();
        var expectedDescription = "Description";
        var expectedImageUrl = "ImageUrl";
        var expectedMaxScore = 100;
        var expectedName = "Quiz";
        var expectedQuizTypeId = Guid.NewGuid();

        Quiz quiz = builder.WithDescription(expectedDescription)
            .WithImageUrl(expectedImageUrl)
            .WithMaxScore(expectedMaxScore)
            .WithName(expectedName)
            .WithQuizTypeId(expectedQuizTypeId)
            .Build();

        Assert.Multiple(() =>
        {
            Assert.That(expectedDescription, Is.EqualTo(quiz.Description));
            Assert.That(expectedImageUrl, Is.EqualTo(quiz.ImageUrl));
            Assert.That(expectedMaxScore, Is.EqualTo(quiz.MaxScore));
            Assert.That(expectedName, Is.EqualTo(quiz.Name));
            Assert.That(expectedQuizTypeId, Is.EqualTo(quiz.QuizTypeId));
        });
    }

    [Test]
    public void WithDescription_Sets_Description_Property_And_Returns_This()
    {
        var builder = new QuizBuilder();
        var expectedDescription = "Description";

        IQuizBuilder returnedBuilder = builder.WithDescription(expectedDescription);

        Assert.Multiple(() =>
        {
            Assert.That(expectedDescription, Is.EqualTo(builder.Build().Description));
            Assert.That(builder, Is.SameAs(returnedBuilder));
        });
    }

    [Test]
    public void WithImageUrl_Sets_ImageUrl_Property_And_Returns_This()
    {
        var builder = new QuizBuilder();
        var expectedImageUrl = "ImageUrl";

        IQuizBuilder returnedBuilder = builder.WithImageUrl(expectedImageUrl);

        Assert.Multiple(() =>
        {
            Assert.That(expectedImageUrl, Is.EqualTo(builder.Build().ImageUrl));
            Assert.That(builder, Is.SameAs(returnedBuilder));
        });
    }

    [Test]
    public void WithMaxScore_Sets_MaxScore_Property_And_Returns_This()
    {
        var builder = new QuizBuilder();
        var expectedMaxScore = 100;

        IQuizBuilder returnedBuilder = builder.WithMaxScore(expectedMaxScore);

        Assert.Multiple(() =>
        {
            Assert.That(expectedMaxScore, Is.EqualTo(builder.Build().MaxScore));
            Assert.That(builder, Is.SameAs(returnedBuilder));
        });
    }

    [Test]
    public void WithName_Sets_Name_Property_And_Returns_This()
    {
        var builder = new QuizBuilder();
        var expectedName = "Quiz";

        IQuizBuilder returnedBuilder = builder.WithName(expectedName);

        Assert.Multiple(() =>
        {
            Assert.That(expectedName, Is.EqualTo(builder.Build().Name));
            Assert.That(builder, Is.SameAs(returnedBuilder));
        });
    }

    [Test]
    public void WithQuizTypeId_Sets_QuizTypeId_Property_And_Returns_This()
    {
        var builder = new QuizBuilder();
        var quizTypeId = Guid.NewGuid();

        IQuizBuilder returnedBuilder = builder.WithQuizTypeId(quizTypeId);

        Assert.Multiple(() =>
        {
            Assert.That(quizTypeId, Is.EqualTo(builder.Build().QuizTypeId));
            Assert.That(builder, Is.SameAs(returnedBuilder));
        });
    }
}
