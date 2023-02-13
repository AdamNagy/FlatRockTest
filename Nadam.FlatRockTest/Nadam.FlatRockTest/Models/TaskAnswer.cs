using Nadam.FlatRockTest.DataAccess.Contracts;

namespace Nadam.FlatRockTest.Models
{
    public class TaskAnswer : IdentityEntity, IIdentityEntity
    {
        public virtual Quote Quote { get; set; }
        public virtual User User { get; set; }
        public DateTime TaskTaken { get; set; }
        public bool IsCorrect { get; set; }
    }
}
