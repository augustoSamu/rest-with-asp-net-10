using Microsoft.EntityFrameworkCore;
using rest_with_asp_net_10.Context;

namespace rest_with_asp_net_10.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private MSSQLContext _context;
        private DbSet<T> _dbSet;

        public Repository(MSSQLContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public T Create(T item)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));

            _dbSet.Add(item);
            _context.SaveChanges();

            return item;
        }

        public T Update(T item)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));

            _dbSet.Update(item);
            _context.SaveChanges();

            return item;
        }

        public void Delete(int id)
        {
            T item = GetById(id);

            if (item is null)
                throw new ArgumentNullException(nameof(item));

            _dbSet.Remove(item);
            _context.SaveChanges();
        }

        public bool Exists(int id)
        {
            return GetById(id) != null;
        }
    }
}