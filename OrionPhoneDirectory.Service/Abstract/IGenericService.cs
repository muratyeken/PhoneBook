using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OrionPhoneDirectory.Service.Abstract
{
    public interface IGenericService<T>

    {
        bool Add(T item);
        bool Add(List<T> items);
        bool Update(T item);
        bool Remove(T item);
        bool Remove(int id);
        bool RemoveAll(Expression<Func<T, bool>> exp);
        T GetByID(int id);
        IQueryable<T> GetByID(int id, params Expression<Func<T, object>>[] includes);
        T GetByDefault(Expression<Func<T, bool>> exp);
        List<T> GetActive();
        IQueryable<T> GetActive(params Expression<Func<T, object>>[] includes);
        List<T> GetDefault(Expression<Func<T, bool>> exp);
        List<T> GetAll();
        IQueryable<T> GetAll(params Expression<Func<T, object>>[] includes);
        bool Activate(int id);
        bool Any(Expression<Func<T, bool>> exp);
    }
}
