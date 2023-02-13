using Microsoft.EntityFrameworkCore;

using Nadam.FlatRockTest.DataAccess.Contracts;
using Nadam.FlatRockTest.Models;

namespace Nadam.FlatRockTest.DataAccess
{
    public class QuoteAuthorRepository : Repository<QuoteAuthor>, IRepository<QuoteAuthor>
    {
        public QuoteAuthorRepository(DbContext context) : base(context)
        {
        }
    }
}
