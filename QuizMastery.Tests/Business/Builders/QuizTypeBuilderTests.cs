using QuizMastery.Business.Builders;
using QuizMastery.Business.Builders.IBuilders;
using QuizMastery.DataAccess.Entities;

namespace QuizMastery.Tests.Business.Builders;

[TestFixture]
public class QuizTypeBuilderTests
{
    [Test]
    public void Build_Returns_QuizType_Instance()
    {
        var builder = new QuizTypeBuilder();

        QuizType quizType = builder.Build();

        Assert.That(quizType, Is.Not.Null);
        Assert.That(quizType, Is.InstanceOf<QuizType>());
    }

    [Test]
    public void Build_Returns_QuizType_Instance_With_Properties_Set()
    {
        var builder = new QuizTypeBuilder();
        var expectedId = Guid.NewGuid();
        var expectedName = "Test Quiz";

        QuizType quizType = builder.WithId(expectedId)
            .WithName(expectedName)
            .Build();

        Assert.That(expectedId, Is.EqualTo(quizType.Id));
        Assert.That(expectedName, Is.EqualTo(quizType.Name));
    }

    [Test]
    public void WithId_Sets_Id_Property_And_Returns_This()
    {
        var builder = new QuizTypeBuilder();
        var expectedId = Guid.NewGuid();

        IQuizTypeBuilder returnedBuilder = builder.WithId(expectedId);

        Assert.That(expectedId, Is.EqualTo(builder.Build().Id));
        Assert.That(builder, Is.SameAs(returnedBuilder));
    }

    [Test]
    public void WithName_Sets_Name_Property_And_Returns_This()
    {
        var builder = new QuizTypeBuilder();
        var expectedName = "Test Quiz";

        IQuizTypeBuilder returnedBuilder = builder.WithName(expectedName);

        Assert.That(expectedName, Is.EqualTo(builder.WithName(expectedName).Build().Name));
        Assert.That(builder, Is.SameAs(returnedBuilder));
    }
}
