using isv.Models;
using Microsoft.EntityFrameworkCore;

namespace isv.Database
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
          : base(options)
        {
        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
        }
    }
}
