using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace KempsTuroTuro.Data
{
    public interface IRepository<T, I> where T : class
    {
        T GetById(I id);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
        T Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        IQueryable<T> Query(Expression<Func<T, bool>> where);
    }

}
