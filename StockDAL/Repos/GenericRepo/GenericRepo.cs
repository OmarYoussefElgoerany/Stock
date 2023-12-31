using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockDAL.Repos.GenericRepo
{
    public class GenericRepo<TEntity> : IGenericRepo<TEntity> where TEntity : class
    {
        private readonly AppDbContext dbContext;
        public GenericRepo(AppDbContext appDbContext)
        {
            this.dbContext = appDbContext;
        }

        public List<TEntity> GetAll() => dbContext.Set<TEntity>().ToList();


        public TEntity? GetById(int id) => dbContext.Set<TEntity>().Find(id);
        
        public TEntity Add(TEntity entity)
        {
            dbContext.Set<TEntity>().Add(entity);
            return entity;
        }
        public TEntity Update(TEntity entity)
        {
            dbContext.Set<TEntity>().Update(entity);
            return entity;
        }

        public TEntity Delete(TEntity entity)
        {
            dbContext.Set<TEntity>().Remove(entity);
            return entity;
        }

    }
}
