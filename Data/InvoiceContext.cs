using Microsoft.EntityFrameworkCore;
using BuggyApp.Models;

namespace BuggyApp.Data
{
    public class InvoiceContext : DbContext
    {
        public InvoiceContext(DbContextOptions<InvoiceContext> options) : base(options)
        {
        }

        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Invoice>()
                .HasMany(i => i.Items)
                .WithOne(item => item.Invoice)
                .HasForeignKey(item => item.InvoiceID);

            // Seed data
            modelBuilder.Entity<Invoice>().HasData(
                new Invoice { InvoiceID = 1, CustomerName = "John Doe" }
            );

            modelBuilder.Entity<InvoiceItem>().HasData(
                new InvoiceItem { ItemID = 1, InvoiceID = 1, Name = "Widget A", Price = 19.99m },
                new InvoiceItem { ItemID = 2, InvoiceID = 1, Name = "Widget B", Price = 29.99m },
                new InvoiceItem { ItemID = 3, InvoiceID = 1, Name = "Widget C", Price = 39.99m }
            );
        }
    }
}
