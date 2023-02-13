namespace Nadam.FlatRockTest.DataAccess.Contracts
{
    public interface IRepository<T> where T : IIdentityEntity
    {
        public IEnumerable<T> Read(int page, int pageSize);
        public T Read(Guid id);

        public void Delete(T entity, bool soft);
        public void Insert(T entity);
        public void Replace(T entity);
    }
}
