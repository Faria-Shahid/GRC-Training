// Notes to self
// Fluent API is a coding style where you chain method
// calls together in a sentence-like flow. 
// EF Core's automatic detection is called conventions.
// Fluent API is what you reach for when conventions aren't
// enough.


using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Book> Books => Set<Book>();
    public DbSet<Author> Authors => Set<Author>();
    public DbSet<Tag> Tags => Set<Tag>();
    public DbSet<BookTag> BookTags => Set<BookTag>();


    // Teaches EF things it can't infer: composite PK, non-standard nav name
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Composite PK for the join table
        modelBuilder.Entity<BookTag>()
            .HasKey(bt => new { bt.BookId, bt.TagId });

        modelBuilder.Entity<BookTag>()
            .HasOne(bt => bt.Book)
            .WithMany()
            .HasForeignKey(bt => bt.BookId);

        modelBuilder.Entity<BookTag>()
            .HasOne(bt => bt.Tag)
            .WithMany()
            .HasForeignKey(bt => bt.TagId);

    }

    public async Task SeedAsync()
    {
        if (Authors.Any()) return;  // already seeded — don't run again

        var authors = new List<Author>
        {
            new Author { Name = "George Orwell" },
            new Author { Name = "J.K. Rowling" },
            new Author { Name = "Frank Herbert" }
        };
        Authors.AddRange(authors);
        await SaveChangesAsync();  // save authors first so EF assigns their IDs

        var tags = new List<Tag>
        {
            new Tag { Name = "Fiction" },
            new Tag { Name = "Science Fiction" },
            new Tag { Name = "Fantasy" },
            new Tag { Name = "Dystopian" }
        };
        Tags.AddRange(tags);
        await SaveChangesAsync();  // save tags so their IDs are assigned

        var books = new List<Book>
        {
            new Book("1984",                                        328, authors[0].Id, 1949) { Isbn = "978-0451524935" },
            new Book("Animal Farm",                                 112, authors[0].Id, 1945) { Isbn = "978-0451526342" },
            new Book("Harry Potter and the Philosopher's Stone",    223, authors[1].Id, 1997) { Isbn = "978-0439708180" },
            new Book("Harry Potter and the Chamber of Secrets",     251, authors[1].Id, 1998) { Isbn = "978-0439064873" },
            new Book("Harry Potter and the Prisoner of Azkaban",    317, authors[1].Id, 1999) { Isbn = "978-0439136365" },
            new Book("Dune",                                        412, authors[2].Id, 1965) { Isbn = "978-0441013593" },
            new Book("Dune Messiah",                                226, authors[2].Id, 1969) { Isbn = "978-0593098233" },
            new Book("Children of Dune",                            408, authors[2].Id, 1976) { Isbn = "978-0593098240" }
        };
        Books.AddRange(books);
        await SaveChangesAsync();  // save books so their IDs are assigned

        BookTags.AddRange(
            new BookTag { BookId = books[0].Id, TagId = tags[0].TagId },  // 1984 → Fiction
            new BookTag { BookId = books[0].Id, TagId = tags[3].TagId },  // 1984 → Dystopian
            new BookTag { BookId = books[2].Id, TagId = tags[2].TagId },  // HP Philosopher's Stone → Fantasy
            new BookTag { BookId = books[3].Id, TagId = tags[2].TagId },  // HP Chamber of Secrets → Fantasy
            new BookTag { BookId = books[5].Id, TagId = tags[1].TagId },  // Dune → Science Fiction
            new BookTag { BookId = books[6].Id, TagId = tags[1].TagId }   // Dune Messiah → Science Fiction
        );
        await SaveChangesAsync();
    }
}
