using Microsoft.EntityFrameworkCore;
using QuizMastery.DataAccess.Context;
using QuizMastery.DataAccess.Entities;
using QuizMastery.DataAccess.Repository;

namespace QuizMastery.Tests.DataAccess.Repository;

[TestFixture]
public class BaseRepositoryTests
{
    [Test]
    public async Task AddAsync_Test()
    {
        var options = new DbContextOptionsBuilder<BaseContext>()
            .UseInMemoryDatabase(databaseName: "QuizMasteryTestDB")
            .Options;

        using var context = new BaseContext(options);
        var repository = new BaseRepository<QuizType>(context);
        var entity = new QuizType()
        {
            Id = Guid.NewGuid(),
            Name = "QuizType"
        };

        await repository.AddAsync(entity);

        Assert.That(context.QuizTypes.Contains(entity));
    }

    [Test]
    public async Task GetAllAsync_Test()
    {
        var options = new DbContextOptionsBuilder<BaseContext>()
            .UseInMemoryDatabase(databaseName: "QuizMasteryTestDB")
            .Options;

        using var context = new BaseContext(options);

        var data = new List<QuizType>()
        {
            new()
            {
                Id = Guid.NewGuid(),
                Name = "FirstQuizType"
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "SecondQuizType"
            }
        };

        context.AddRange(data);
        context.SaveChanges();

        var repository = new BaseRepository<QuizType>(context);
        var result = await repository.GetAllAsync();

        foreach (var entity in data)
        {
            Assert.That(result.Any(x => x.Id == entity.Id && x.Name == entity.Name), Is.True);
        }
    }

    [Test]
    public async Task GetAsync_Test()
    {
        var options = new DbContextOptionsBuilder<BaseContext>()
            .UseInMemoryDatabase(databaseName: "QuizMasteryTestDB")
            .Options;

        using var context = new BaseContext(options);

        Guid firstId = Guid.NewGuid();
        Guid secondId = Guid.NewGuid();
        var firstQuizType = new QuizType() { Id = firstId, Name = "FirstQuizType" };
        var secondQuizType = new QuizType() { Id = secondId, Name = "SecondQuizType" };
        
        context.AddRange(firstQuizType, secondQuizType);
        context.SaveChanges();

        var repository = new BaseRepository<QuizType>(context);

        var result = await repository.GetAsync(x => x.Id.Equals(firstId));

        Assert.That(result, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(result.Id, Is.EqualTo(firstQuizType.Id));
            Assert.That(result.Name, Is.EqualTo(firstQuizType.Name));
        });
    }

    [Test]
    public async Task RemoveAsync_Test()
    {
        var options = new DbContextOptionsBuilder<BaseContext>()
            .UseInMemoryDatabase(databaseName: "QuizMasteryTestDB")
            .Options;

        using var context = new BaseContext(options);
        Guid id = Guid.NewGuid();
        var entity = new QuizType { Id = id, Name = "QuizType" };
        context.QuizTypes.Add(entity);
        context.SaveChanges();

        var repository = new BaseRepository<QuizType>(context);

        await repository.RemoveAsync(entity);

        Assert.That(context.QuizTypes.Any(x => x.Id == id), Is.False);
    }

    [Test]
    public async Task SaveAsync_Test()
    {
        var options = new DbContextOptionsBuilder<BaseContext>()
            .UseInMemoryDatabase(databaseName: "QuizMasteryTestDB")
            .Options;

        using var context = new BaseContext(options);

        var repository = new BaseRepository<QuizType>(context);
        await repository.SaveAsync();
    }

    [Test]
    public async Task UpdateAsync_Test()
    {
        var options = new DbContextOptionsBuilder<BaseContext>()
            .UseInMemoryDatabase(databaseName: "QuizMasteryTestDB")
            .Options;

        using var context = new BaseContext(options);
        var entity = new QuizType { Id = Guid.NewGuid(), Name = "QuizType" };
        context.QuizTypes.Add(entity);
        context.SaveChanges();

        var repository = new BaseRepository<QuizType>(context);
        entity.Name = "UpdatedQuizType";

        var result = await repository.UpdateAsync(entity);

        Assert.That(result.Name, Is.EqualTo("UpdatedQuizType"));
    }
}
