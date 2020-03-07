using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab1.models;
using Microsoft.EntityFrameworkCore;

namespace lab1.repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly MyAppContext dbContext;
        
        public GenericRepository(MyAppContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task Create(TEntity entity)
        {
            await dbContext.Set<TEntity>().AddAsync(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            dbContext.Set<TEntity>().Remove(entity);
        }

        public IQueryable<TEntity> GetAll()
        {
            return dbContext.Set<TEntity>().AsNoTracking();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await dbContext.Set<TEntity>()
                .FindAsync(id);
        }

        public async Task Update(int id, TEntity entity)
        {
            dbContext.Set<TEntity>().Update(entity);
            await dbContext.SaveChangesAsync();

        }
    }
}
