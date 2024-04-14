using Microsoft.EntityFrameworkCore;
using QuizMastery.DataAccess.Context;

namespace QuizMastery.Tests.DataAccess.Context;

[TestFixture]
public class BaseContextTests
{
    [Test]
    public void DbSet_Properties_Are_Initialized()
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

    [Test]
    public void DbContext_Is_Configured_Properly()
    {
        var options = new DbContextOptionsBuilder<BaseContext>()
            .UseInMemoryDatabase(databaseName: "QuizMasteryTestDB")
            .Options;

        using var context = new BaseContext(options);
        Assert.That(context.Database, Is.Not.Null);
    }
}
