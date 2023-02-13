using System.Reflection.Metadata;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

using Nadam.FlatRockTest.Models;

namespace Nadam.FlatRockTest.DataAccess
{
    public class QuoteQuizGameContext : IdentityDbContext<User>
    {
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<QuoteAuthor> QuoteAuthor { get; set; }
        public DbSet<TaskAnswer> Answers { get; set; }

        public QuoteQuizGameContext(DbContextOptions options) : base(options) { }
    }
}
