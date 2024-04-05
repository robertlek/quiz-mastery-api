﻿using Microsoft.EntityFrameworkCore;
using QuizMastery.DataAccess.Context;
using QuizMastery.DataAccess.Repository.IRepository;
using System.Linq.Expressions;

namespace QuizMastery.DataAccess.Repository;

public class BaseRepositoy<T>(BaseContext db) : IBaseRepository<T> where T : class
{
    private readonly BaseContext _db = db;
    private readonly DbSet<T> _dbSet = db.Set<T>();

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await SaveAsync();
    }

    public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null)
    {
        IQueryable<T> query = _dbSet;

        if (filter != null)
        {
            query = query.Where(filter);
        }

        return await query.ToListAsync();
    }

    public async Task<T?> GetAsync(Expression<Func<T, bool>> filter, bool tracked = true)
    {
        IQueryable<T> query = _dbSet;

        if (!tracked)
        {
            query = query.AsNoTracking();
        }

        query = query.Where(filter);

        return await query.FirstOrDefaultAsync();
    }

    public async Task RemoveAsync(T entity)
    {
        _dbSet.Remove(entity);
        await SaveAsync();
    }

    public async Task SaveAsync()
    {
        await _db.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await SaveAsync();
    }
}
