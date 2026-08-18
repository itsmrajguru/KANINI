using Microsoft.EntityFrameworkCore;
using LibraryManagementAPI.Models;


/* In the MERN stack, our each model exports itself and then it is called in the controller 
and it directly talks to Mongoose where Mongoose make changes in the MongoDB database

but in .NET
We have a single DbContext which acts as central context of the database and 
it includes all models in it and these models are called in the services using _context*/


/* Central Idea :
So the central idea is like If I receive some data in thec controller and I want to push it to Mysql
then I will call the table of MySQL from DB context representing as model object.
and use the model object in the controller using _context and this line context.() [sum operation] will
directly connect to Mysql database right

and this line _context.() is the actual Entity Framework Core 
thus EF Core isn't one particular line of code in your project.
It's a library/framework that your project uses.
Your code uses EF Core through things like:

DbContext
DbSet<Book>
ToListAsync()
FindAsync()
Add()
SaveChangesAsync()

These are provided by EF Core.
*/



namespace LibraryManagementAPI.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {
        }

        // Each DbSet = one table in the database

        /* DbSet<Book> is not a copy of the database table. It is an EF Core interface through
         which our C# application works with the actual database data. */
        public DbSet<Book> Books { get; set; }
        /* get; and set; gives controlled access to the values.
        where get means taking data ,and set means setting value to the data */
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<Fine> Fines { get; set; }
        public DbSet<User> Users { get; set; }

        /* database relationship/configuration section.
        
        this is a type of validation, where we are setting some rules for the tables
        so it mainly focuses on relationship between the tables
        
        ex..Book
        One Book has one Author, and one Author can have many Books.*/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Category)
                .WithMany(c => c.Books)
                .HasForeignKey(b => b.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Issue>()
                .HasOne(i => i.Book)
                .WithMany(b => b.Issues)
                .HasForeignKey(i => i.BookId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Issue>()
                .HasOne(i => i.Member)
                .WithMany(m => m.Issues)
                .HasForeignKey(i => i.MemberId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Fine>()
                .HasOne(f => f.Issue)
                .WithOne(i => i.Fine)
                .HasForeignKey<Fine>(f => f.IssueId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Issue>()
                .Property(i => i.Status)
                .HasConversion<string>();

            modelBuilder.Entity<User>()
                .Property(u => u.Role)
                .HasConversion<string>();

            modelBuilder.Entity<Member>()
                .Property(m => m.MembershipType)
                .HasConversion<string>();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();


        }
    }
}
