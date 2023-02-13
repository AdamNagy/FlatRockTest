using Microsoft.EntityFrameworkCore;

using Nadam.FlatRockTest.DataAccess.Contracts;
using Nadam.FlatRockTest.Models;

namespace Nadam.FlatRockTest.DataAccess
{
    public sealed class QuoteRepository : Repository<Quote>, IRepository<Quote>
    {
        public QuoteRepository(DbContext context) : base(context)
        {
        }
    }
}
