using campapi.src.Domain.Models;
using campApi.src.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace campapi.src.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration config;

        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration config) : base(options)
        {
            this.config = config;
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<QuestionModel> Questions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = config.GetConnectionString("Default");
            optionsBuilder.UseSqlite(connectionString);
            optionsBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

}