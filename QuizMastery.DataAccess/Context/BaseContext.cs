using Microsoft.EntityFrameworkCore;

namespace QuizMastery.DataAccess.Context;

public class BaseContext(DbContextOptions options) : DbContext(options)
{
    // Work in progress.
}
