using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RepositoryContracts.Models;

namespace Repositories
{
    internal class ApplicationContext : DbContext
    {
        private const string ConnectionString = "SqlConnectionString";

        public DbSet<Quiz> Quizes { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string str = AppSettings.Configuration.GetConnectionString(ConnectionString);
            optionsBuilder.UseSqlServer(str);
        }
    }
}
