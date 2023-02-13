namespace Nadam.FlatRockTest.DataAccess.Contracts
{
    public interface IIdentityEntity
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public bool Deleted { get; set; }
        public DateTime? DeletedOn { get; set; }
    }

    public class IdentityEntity
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public bool Deleted { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
