using Microsoft.EntityFrameworkCore;
using Promo.Data.AppData;
using Promo.Data.Repos.IRepo;
using System.Linq.Expressions;

namespace Promo.Data.Repos.Repo;

public class GenericRepo<T> : IGenericRepo<T> where T : class
{
    private readonly AppDbContext _db;
    internal DbSet<T> dbSet;

    public GenericRepo(AppDbContext db)
    {
        _db = db;
        this.dbSet = _db.Set<T>();//_db.Products.Include(u => u.Category).Include(u=>u.PromoCover);
    }
    public void Add(T entity)
    {
        dbSet.Add(entity);
    }

    //includeProp - "Category,PromoCover"

    public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
    {
        IQueryable<T> query = dbSet;
        if (filter != null)
        {
            query = query.Where(filter);
        }
        if (includeProperties != null)
        {
            foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProp);
            }
        }
        return query.ToList();
    }

    public T GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = true)
    {
        if (tracked)
        {
            IQueryable<T> query = dbSet;


            query = query.Where(filter);
            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.FirstOrDefault();
        }
        else
        {
            IQueryable<T> query = dbSet.AsNoTracking();

            query = query.Where(filter);
            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.FirstOrDefault();
        }
    }

    public void Remove(T entity)
    {
        dbSet.Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> entity)
    {
        dbSet.RemoveRange(entity);
    }
}