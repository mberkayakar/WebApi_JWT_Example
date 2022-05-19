using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IGenericService<T> where T : class
    {
        void add(T entity);
        void remove(T entity);
        void update(T entity);
        T GetT(Expression<Func<T, bool>> expression);
        IEnumerable<T> GetAll(Expression<Func<T, bool>> expression);
    }
}
