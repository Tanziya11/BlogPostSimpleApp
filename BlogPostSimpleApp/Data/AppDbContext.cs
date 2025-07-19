using BlogPostSimpleApp.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<BlogType> BlogTypes { get; set; }
    public DbSet<PostType> PostTypes { get; set; }
    public DbSet<User> users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BlogDb;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Blog → BlogType (FK)
        modelBuilder.Entity<Blog>()
            .HasOne(b => b.BlogType)
            .WithMany(bt => bt.Blogs)
            .HasForeignKey(b => b.BlogTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        // Post → PostType (FK)
        modelBuilder.Entity<Post>()
            .HasOne(p => p.PostType)
            .WithMany(pt => pt.Posts)
            .HasForeignKey(p => p.PostTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        // Post → Blog (FK)
        modelBuilder.Entity<Post>()
            .HasOne(p => p.Blog)
            .WithMany(b => b.Posts)
            .HasForeignKey(p => p.BlogId)
            .OnDelete(DeleteBehavior.Cascade);

        // Post → User (FK)
        modelBuilder.Entity<Post>()
            .HasOne(p => p.User)
            .WithMany(u => u.Posts)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // User field constraints
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(u => u.UserId);

            entity.Property(u => u.Name)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.Property(u => u.Email)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.Property(u => u.PhoneNumber)
                  .HasMaxLength(15);
        });
    }
}