using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Nadam.FlatRockTest.DataAccess.Contracts
{
    public abstract class Repository<T> : IRepository<T> where T: class, IIdentityEntity
    {
        private readonly DbContext _context;
        private IQueryable<T> _query;

        public Repository(DbContext context)
        {
            _context = context;
            _query = _context.Set<T>().AsNoTracking();
        }

        public void Delete(T entity, bool soft)
        {
            var table = _context.Set<T>();
            var existing = Read(entity.Id);


            if (existing == null)
            {
                throw new ArgumentException("Record does not exist");
            }

            if (soft)
            {
                existing.Deleted = true;
                existing.DeletedOn = DateTime.Now;
            }
            else
            {
                table.Remove(existing);
            }

            _context.SaveChanges();
        }

        public void Insert(T entity)
        {
            try
            {
                var existing = Read(entity.Id);

                if(existing != null)
                {
                    throw new ArgumentException("Record already exist");
                }

                var table = _context.Set<T>();
                table.Add(entity);
                _context.SaveChanges();
            }
            catch
            {

            }
        }

        public IEnumerable<T> Read(int page, int pageSize)
            => _query.Skip((page-1)*pageSize).Take(pageSize);

        public T Read(Guid id)
            => _query.FirstOrDefault(p => p.Id == id);

        public void Replace(T entity)
        {
            var transaction = _context.Database.BeginTransaction();

            try
            {
                var existing = Read(entity.Id);

                if (existing == null)
                {
                    throw new ArgumentException("Record does not exist");
                }

                
                var table = _context.Set<T>();
                table.Remove(existing);
                table.Add(entity);

                _context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }
        }
    }
}
