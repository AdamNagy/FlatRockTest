using Nadam.FlatRockTest.DataAccess.Contracts;

namespace Nadam.FlatRockTest.Models
{
    public class Quote : IdentityEntity, IIdentityEntity
    {
        public string QuoteText { get; set; }
        public virtual QuoteAuthor Author { get; set; }
    }
}
