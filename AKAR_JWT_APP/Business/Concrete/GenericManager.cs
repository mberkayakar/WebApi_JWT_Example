using Business.Abstract;
using Core;
using Core.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class GenericManager<T> : IGenericService<T> where T : class , IEntity , new() 
    {


        private IGenericRepository<T> _item;

        public GenericManager(IGenericRepository<T> _item)
        {
            this._item = _item;
        }



        public void add(T entity)
        {
           _item.add(entity);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> expression)
        {

           return _item.GetAll(expression);
        }

        public T GetT(Expression<Func<T, bool>> expression)
        {
           return _item.GetT(expression);
        }

        public void remove(T entity)
        {
            _item.remove(entity);
        }

        public void update(T entity)
        {
             _item.update(entity);
        }
    }
}
