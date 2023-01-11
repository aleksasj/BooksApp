using Microsoft.EntityFrameworkCore;

namespace BooksApp.Models
{
    public class LibDBContext : DbContext
    {
        public LibDBContext(DbContextOptions<LibDBContext> options): base(options)
        {
        }
        public DbSet<Book> Book { get; set; }
        public DbSet<Author> Author { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }

    public class Book
    {
        public int Id { get; internal set; }
        public string? Title { get; set; }
        public int AuthorId { internal get; set; }
        public  Author Author { get; }

    }

    public class Author
    {
        public int Id { get; internal set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public ICollection<Book> Books { get; }
    }

}
