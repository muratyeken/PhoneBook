using Microsoft.EntityFrameworkCore;
using OrionPhoneDirectory.Domain.Entities;
using OrionPhoneDirectory.Repository.Abstract;
using OrionPhoneDirectory.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace OrionPhoneDirectory.Repository.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly OrionPhoneDirectoryContext _context;
        public GenericRepository(OrionPhoneDirectoryContext context)

        {
            _context = context;
        }
        public bool Add(T item)
        {
            try
            {
                item.AddedDate = DateTime.Now;
                _context.Set<T>().Add(item);
                return Save() > 0; //1 satir etkileniyorsa true dondurur.
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool Add(List<T> items)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    //_context.Set<T>().AddRange(items);
                    foreach (T item in items)
                    {
                        item.AddedDate = DateTime.Now;
                        _context.Set<T>().Add(item);
                    }
                    ts.Complete();
                    return Save() > 0; //1 veya daha fazla satir etkileniyorsa true dondur..
                }

            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool Any(Expression<Func<T, bool>> exp) => _context.Set<T>().Any(exp);

        public List<T> GetActive() => _context.Set<T>().Where(x => x.IsActive == true).ToList();

        public IQueryable<T> GetActive(params Expression<Func<T, object>>[] includes)
        {
            var query = _context.Set<T>().Where(x => x.IsActive == true);
            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }
            return query;
        }
        public List<T> GetAll() => _context.Set<T>().ToList();

        public IQueryable<T> GetAll(params Expression<Func<T, object>>[] includes)
        {
            var query = _context.Set<T>().AsQueryable();
            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }
            return query;
        }
        public T GetByDefault(Expression<Func<T, bool>> exp) => _context.Set<T>().FirstOrDefault(exp);

        public T GetByID(int id) => _context.Set<T>().Find(id);

        public IQueryable<T> GetByID(int id, params Expression<Func<T, object>>[] includes)
        {
            var query = _context.Set<T>().Where(x => x.ID == id);
            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }
            return query;
        }

        public List<T> GetDefault(Expression<Func<T, bool>> exp) => _context.Set<T>().Where(exp).ToList();

        public bool Remove(T item)
        {
            item.IsActive = false;
            return Update(item);
        }

        public bool Remove(int id)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    T item = GetByID(id);
                    item.IsActive = false;
                    ts.Complete();
                    return Update(item);
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool RemoveAll(Expression<Func<T, bool>> exp)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var collection = GetDefault(exp); //verilen ifadeye gore ilgili nesneleri doner
                    int counter = 0;
                    foreach (var item in collection)
                    {
                        item.IsActive = false;
                        bool opreationResult = Update(item);
                        if (opreationResult) counter++;//siradaki item'in silinmesi basarili ise counteri arttirir.
                    }
                    if (collection.Count == counter) ts.Complete(); //koleksiyondaki eleman sayisi ile silinmesi gerceklesen eleman sayisi esit ise islem basarilidir.
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool Activate(int id)
        {
            T item = GetByID(id);
            item.IsActive = true;
            return Update(item);
        }
        public int Save()
        {
            return _context.SaveChanges();
        }
        public bool Update(T item)
        {
            try
            {
                item.ModifiedDate = DateTime.Now;
                _context.Set<T>().Update(item);
                return Save() > 0;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public void DetachEntity(T item)
        {
            _context.Entry<T>(item).State = EntityState.Detached; //bir entryi takibi birakmak icin kullanilir
        }
    }
}
