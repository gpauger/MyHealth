using MyHealth.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MyHealth.DAL
{
    public class UserContext : DbContext
    {

        public UserContext() : base("UserContext")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Entry> Entries { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Measurements> Measurements { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<MyHealth.Models.ScoreCard> ScoreCards { get; set; }
    }
}