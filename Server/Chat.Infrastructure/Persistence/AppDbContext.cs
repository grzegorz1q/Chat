using Chat.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Chat.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Message> Messages { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Message>(entity =>
            {
                entity.Property(e => e.Username).IsRequired().HasMaxLength(20);
                entity.Property(e => e.Content).IsRequired().HasMaxLength(500);
            });
        }
    }
}
