using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Organization> Organizations { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<AccountInfo> AccountInfos { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<TagAccountInfo> TagAccountInfos { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TagAccountInfo>()
            .HasKey(ta => new { ta.TagId, ta.AccountInfoId });

        modelBuilder.Entity<TagAccountInfo>()
            .HasOne(ta => ta.Tag)
            .WithMany(t => t.TagAccountInfos)
            .HasForeignKey(ta => ta.TagId);

        modelBuilder.Entity<TagAccountInfo>()
            .HasOne(ta => ta.AccountInfo)
            .WithMany(ai => ai.TagAccountInfos)
            .HasForeignKey(ta => ta.AccountInfoId);
    }
}
