using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Data
{
    public class QaContext : DbContext
    {
        public QaContext(DbContextOptions<QaContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<UserAnswer> UserAnswers { get; set; }
    }
}