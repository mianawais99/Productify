using System;
using System.Collections.Generic;
using System.Linq;
using DbModels.Models;
using Microsoft.EntityFrameworkCore;
using Productify.Repo.IRepository;
using Productify.Repo;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    private readonly ApplicationContext _context;
    private readonly DbSet<T> _entities;

    public Repository(ApplicationContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _entities = _context.Set<T>();
    }

    public IEnumerable<T> GetAll()
    {
        return _entities.ToList();
    }

    public T Get(int id)
    {
        return _entities.Find(id);
    }

    public void Insert(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        _entities.Add(entity);
    }

    public void Update(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        _entities.Update(entity);
    }

    public void Delete(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        _entities.Remove(entity);
    }

    public void Remove(T entity)
    {
        Delete(entity); // Alias for Delete method
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}
