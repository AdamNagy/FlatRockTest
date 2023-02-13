using Nadam.FlatRockTest.DataAccess.Contracts;

namespace Nadam.FlatRockTest.Models
{
    public class QuoteAuthor : IdentityEntity, IIdentityEntity
    {
        public string Name { get; set; }
    }
}
