using DangerousObjectsDAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DangerousObjectsDAL.Data;

public class DataContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<DangerousObject> DangerousObjects { get; set; } = null!;
    public DbSet<Message> Messages { get; set; } = null!;
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Message>()
            .HasOne(e => e.Sender)
            .WithMany()
            .HasForeignKey(e => e.SenderId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}