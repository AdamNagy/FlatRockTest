using Microsoft.EntityFrameworkCore;

using Nadam.FlatRockTest.DataAccess.Contracts;
using Nadam.FlatRockTest.Models;

namespace Nadam.FlatRockTest.DataAccess
{
    public class TaskAnswerRepository : Repository<TaskAnswer>, IRepository<TaskAnswer>
    {
        public TaskAnswerRepository(DbContext context) : base(context)
        {
        }
    }
}
