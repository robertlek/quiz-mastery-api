using Microsoft.EntityFrameworkCore;

namespace QuizMastery.DataAccess.Context;

public class BaseContext(DbContextOptions<BaseContext> options) : DbContext(options)
{
    // Work in progress.
}
