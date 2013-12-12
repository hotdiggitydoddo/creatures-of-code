using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JotAThought.Domain.Contracts;
using JotAThought.Model;
using System.Data.Entity;

namespace JotAThought.DAL
{
    public class Repository<T> : IRepository<T>
        where T : class
    {
        private readonly DbContext _context;
        protected DbContext context { get { return _context; } }

        public Repository(DbContext context)
        {
            _context = context;
        }

        public Repository()
        {
            _context = new BlogDbContext();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public IEnumerable<T> Query(System.Linq.Expressions.Expression<Func<T, bool>> filter)
        {
            return _context.Set<T>().Where(filter);
        }

        public T Add(T entity)
        {
            _context.Set<T>().Add(entity);
            return entity;
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = System.Data.EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
