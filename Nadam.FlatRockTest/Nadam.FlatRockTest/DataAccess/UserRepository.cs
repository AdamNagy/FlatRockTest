using Microsoft.EntityFrameworkCore;

using Nadam.FlatRockTest.Models;

namespace Nadam.FlatRockTest.DataAccess
{
    public class UserRepository
    {
        private readonly DbContext _context;
        private readonly IQueryable<User> _query;

        public UserRepository(DbContext context)
        {
            _context = context;
            _query = _context.Set<User>().AsNoTracking();
        }

        public void Delete(User entity, bool soft)
        {
            var table = _context.Set<User>();
            var existing = Read(entity.Email);


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

        public void Insert(User entity)
        {
            try
            {
                var existing = Read(entity.Id);

                if (existing != null)
                {
                    throw new ArgumentException("Record already exist");
                }

                var table = _context.Set<User>();
                table.Add(entity);
                _context.SaveChanges();
            }
            catch
            {

            }
        }
        public IEnumerable<User> Read(int page, int pageSize)
            => _query.Skip((page - 1) * pageSize).Take(pageSize);

        public User Read(string id)
            => _query.FirstOrDefault(p => p.Id == id);

        public void Replace(User entity)
        {
            var transaction = _context.Database.BeginTransaction();

            try
            {
                var existing = Read(entity.Id);

                if (existing == null)
                {
                    throw new ArgumentException("Record does not exist");
                }


                var table = _context.Set<User>();
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
