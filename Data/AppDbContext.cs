using ApiPB101.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace ApiPB101.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
            new Category { 
                  Id = 1, 
                  CreatedDate = DateTime.Now,
                  Name = "UI UX",
            },
             new Category
             {
                 Id = 2,
                 CreatedDate = DateTime.Now,
                 Name = "UI",
             },

              new Category
              {
                  Id = 3,
                  CreatedDate = DateTime.Now,
                  Name = "UX",
              }

            );

            modelBuilder.Entity<Book>().HasData(
          new Book
          {
              Id = 1,
              CreatedDate = DateTime.Now,
              Name = "Kitab1",
              Author = "yazici1"
          },
          new Book
          {
              Id = 2,
              CreatedDate = DateTime.Now,
              Name = "Kitab2",
              Author = "yazici2"

          },
          new Book
          {
              Id = 3,
              CreatedDate = DateTime.Now,
              Name = "Kitab3",
              Author = "yazici3"

          }
          );
            base.OnModelCreating(modelBuilder);
        }
    }
}
