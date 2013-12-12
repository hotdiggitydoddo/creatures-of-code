using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JotAThought.Domain.Contracts
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Query(Expression<Func<T, bool>> filter);
        T Add(T entity);
        void Remove(T entity);
        void Update(T entity);
        void Save();
    }
}
