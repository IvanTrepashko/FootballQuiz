using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RepositoryContracts.Models;

namespace Repositories
{
    public class ApplicationContext : DbContext
    {
        private const string ConnectionString = "SqlConnectionString";

        public DbSet<Quiz> Quizes { get; set; }

        public DbSet<AnsweredQuestion> AnsweredQuestions { get; set; }

        public DbSet<AnsweredQuiz> AnsweredQuizes { get; set; }

        public DbSet<QuizAnswer> QuizAnswers { get; set; }

        public DbSet<QuizQuestion> QuizQuestions { get; set; }

        public DbSet<User> Users { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string str = AppSettings.Configuration.GetConnectionString(ConnectionString);
            optionsBuilder.UseSqlServer(str);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnsweredQuestion>()
                .HasOne(x => x.Question)
                .WithMany().OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AnsweredQuestion>()
                .HasOne(x => x.QuizAnswer)
                .WithMany().OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AnsweredQuestion>()
              .HasOne(x => x.Quiz)
              .WithMany().OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AnsweredQuestion>()
              .HasOne(x => x.User)
              .WithMany().OnDelete(DeleteBehavior.Restrict);
        }
    }
}
