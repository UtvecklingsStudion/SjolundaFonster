using SjolundaFonster.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace SjolundaFonster 
{ 
    public class SjolundaFonsterDbContext : DbContext
    {
        public SjolundaFonsterDbContext(DbContextOptions<SjolundaFonsterDbContext> options) : base(options) { }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Window> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Color> ProductColors { get; set; }
        public DbSet<Model> ProductModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Color>().HasData(
                new Color { Id= 1, Name = "Stockholmsvit", Code= "#F2F2EB ", NCS="0500-N" },
                new Color { Id= 6, Name = "Öjablå", Code= "#647C80", NCS="0500-N" },
                new Color { Id = 2, Name = "Köpenhamngrön", Code= "#4F7D47", NCS = "0500-N" },
                new Color { Id = 3, Name = "Sandgul", Code= "#EAC67A", NCS = "0500-N" },
                new Color { Id = 4, Name = "Varmgrå", Code= "#B4BCAD", NCS = "0500-N" },
                new Color { Id = 5, Name = "Engelsk röd", Code= "#8E2011", NCS = "0500-N" }
                );

            modelBuilder.Entity<Model>().HasData(
               new Model { Id = 1, Name = "Anno 1900", Image = "anno_1900" },
               new Model { Id = 2, Name = "Anno 1920", Image = "anno_1920" },
               new Model { Id = 3, Name = "Anno 1930", Image = "anno_1930" }
               );
        }
    }

}