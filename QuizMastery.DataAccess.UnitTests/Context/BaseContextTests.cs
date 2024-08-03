using Microsoft.EntityFrameworkCore;
using QuizMastery.DataAccess.Context;

namespace QuizMastery.DataAccess.UnitTests.Context;

[TestFixture]
public class BaseContextTests
{
    [Test]
    public void BaseContext_WhenInitialized_DatabaseIsNotNull()
    {
        var options = new DbContextOptionsBuilder<BaseContext>()
            .UseInMemoryDatabase(databaseName: "QuizMasteryTestDB")
            .Options;

        using var context = new BaseContext(options);

        Assert.That(context.Database, Is.Not.Null);
    }

    [Test]
    public void BaseContext_WhenInitialized_DbSetPropertiesAreNotNull()
    {
        var options = new DbContextOptionsBuilder<BaseContext>()
            .UseInMemoryDatabase(databaseName: "QuizMasteryTestDB")
            .Options;

        using var context = new BaseContext(options);

        Assert.Multiple(() =>
        {
            Assert.That(context.QuizTypes, Is.Not.Null);
            Assert.That(context.Quizzes, Is.Not.Null);
            Assert.That(context.Questions, Is.Not.Null);
            Assert.That(context.Answers, Is.Not.Null);
        });
    }
}
