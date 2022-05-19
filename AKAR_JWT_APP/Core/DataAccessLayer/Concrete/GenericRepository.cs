using Core.DataAccessLayer.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccessLayer.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class , IEntity,new ()
        //where TContext : DbContext, new()
            
    {
        private readonly DbContext _dbContext;

        public GenericRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

  

        public void add(T entity)
        {

            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
             
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> expression)
        {
            
                if (expression != null)
                {
                    return _dbContext.Set<T>().Where(expression).ToList();
                }

                return _dbContext.Set<T>().ToList();

             
        }

        public T GetT(Expression<Func<T, bool>> expression)
        {
             
                if (expression != null)
                {
                    return _dbContext.Set<T>().Where(expression).FirstOrDefault();
                }

                return _dbContext.Set<T>().FirstOrDefault();
             
        }

        public void remove(T entity)
        {

            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
             
        }

        public void update(T entity)
        {

            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
             
        }
    }
}
