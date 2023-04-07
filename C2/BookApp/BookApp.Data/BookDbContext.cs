using BookApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BookApp.Data;
public class BookDbContext : DbContext
{
    private const string ConnectionString = @"Server=(localdb)\mssqllocaldb;Database=BookDb;Trusted_Connection=True;";
    public DbSet<Book>? Books { get; set; }
    public DbSet<Author>? Authors { get; set; }
    public DbSet<PriceOffer>? PriceOffers { get; set; }
    public DbSet<Tag>? Tags { get; set; }

    public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConnectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookAuthor>()
            .HasKey(x => new { x.BookId, x.AuthorId });
        modelBuilder.Entity<Tag>()
            .HasKey(x => x.TagId);
        modelBuilder.Entity<Tag>()
            .Property(t => t.TagId).HasMaxLength(40)
            .IsRequired();
    }
}
public class BookDbContextFactory : IDesignTimeDbContextFactory<BookDbContext>
{
    public BookDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<BookDbContext>();
        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=BookDb;Trusted_Connection=True;");

        return new BookDbContext(optionsBuilder.Options);
    }
}
