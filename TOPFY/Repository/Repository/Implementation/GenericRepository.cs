using DomainModels.Models.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Repository.DAL;
using Repository.Services.Abstarction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repository.Services.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity
    {
        private readonly AppDbContext context;
        internal DbSet<T> dbSet;
        protected readonly ILogger _logger;

        public GenericRepository(AppDbContext context, ILogger logger)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
            this._logger = logger;

        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task<bool> AddAsync(T entity)
        {
            try
            {
                await context.Set<T>().AddAsync(entity);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public virtual async Task<bool> AddRangeAsync(IList<T> entities)
        {
            try
            {
                await dbSet.AddRangeAsync(entities);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public virtual async Task<bool> DeleteAsync(string id)
        {
            try
            {
                T item = await context.Set<T>().FindAsync(id);
                item.IsDeleted = true;
                item.DeletedDate = DateTime.Now;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public virtual bool Update(T entity)
        {
            try
            {
                context.Set<T>().Update(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression)
        {
            return await dbSet.FirstOrDefaultAsync(expression);
        }
        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression = null)
        {
            if (expression != null)
            {
                if (await dbSet.AnyAsync(expression)) return true;
            }
            if (await dbSet.AnyAsync()) return true;
            return false;
        }

        public virtual async Task<IList<T>> FindAllAsync(Expression<Func<T, bool>> predicate
            ,IList<string> includingItems=null)
        {
            if (includingItems != null)
            {
                foreach (string item in includingItems)
                {
                    dbSet.Include(item);
                }
            }
            return await dbSet.Where(predicate).ToListAsync();
        }
        
    }

}