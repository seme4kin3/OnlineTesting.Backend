using Microsoft.EntityFrameworkCore;
using OnlineQuiz.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineQuiz.Persistance
{
    public class DataContext : DbContext 
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Quiz> Quizs { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Result> Results { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("server=localhost\\sqlexpress;database=onlineQuizdb;trusted_connection=true;TrustServerCertificate=True;");
        //}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Quiz>()
                .HasMany<Question>(q => q.Questions)
                .WithOne(t => t.Quiz)
                .HasForeignKey(t => t.QuizId);

            builder.Entity<Question>()
                .HasMany<Answer>(a => a.Answers)
                .WithOne(q => q.Question)
                .HasForeignKey(q => q.QuestionId);

            builder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email).IsUnique();
            });

            builder.Entity<Result>(r =>
            {
                r.HasOne(u => u.User)
                .WithMany(u => u.Results)
                .HasForeignKey(r => r.IdUser);

                r.HasOne(u => u.Quiz)
                .WithMany(u => u.Results)
                .HasForeignKey(r => r.IdQuiz);
            });


        }
    }
}
