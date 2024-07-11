using Microsoft.EntityFrameworkCore;
using P01_SalesDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_SalesDatabase.Data
{
    internal class ApplicationDbContext:DbContext
    {
       public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Sale> Sales { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=SalesDatabase;Integrated Security=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //by All type of Wayes
            base.OnModelCreating(modelBuilder);
            // Edit Product.Name to up to 50
            modelBuilder.Entity<Product>().Property(p => p.Name)
                .HasMaxLength(50);
            // Edit Customar.Name to up to 100
            modelBuilder.Entity<Customer>().Property(c=>c.Name)
                .HasMaxLength(100);
            //Edit Customar.Email to up to 80 and not Unicode
            modelBuilder.Entity<Customer>().Property(c=>c.Email)
                .HasColumnType("varchar(80)");
            //Edit Store.Name to up to 80
            modelBuilder.Entity<Store>().Property(s => s.Name)
                .HasColumnType("nvarchar(80)");

            

        }
    }
}
