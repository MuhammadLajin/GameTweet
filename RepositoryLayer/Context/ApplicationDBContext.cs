using DomainLayer.Configuration;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace RepositoryLayer.Context
{
    public class ApplicationDBContext : DbContext
    {
        #region props
        public DbSet<User> User { get; set; }
        public DbSet<Tweet> Tweet { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Reply> Reply { get; set; }

        #endregion

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelbuider)
        {
            modelbuider.ApplyConfigurationsFromAssembly(typeof(UserConfiguration).Assembly);
            base.OnModelCreating(modelbuider);
        }

    }
}
