using DataBoard.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace DataBoard.Infrastructure
{
    public class DataboardContext : DbContext
    {        
        public DataboardContext(DbContextOptions<DataboardContext> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<User> Users { get; set; }
    }
}