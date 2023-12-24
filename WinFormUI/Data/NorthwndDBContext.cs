using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormUI.Data
{
    public class NorthwndDBContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=NORTHWND;Integrated Security=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Order details tablosundaki PK nın modellenmesi
            modelBuilder.Entity<OrderDetail>().HasKey(e => new { e.OrderID, e.ProductID });
            modelBuilder.Entity<OrderDetail>().ToTable("Order Details");

            modelBuilder.Entity<OrderDetail>().Property(o => o.UnitPrice).HasColumnType("money");

            modelBuilder.Entity<OrderDetail>()
                .HasOne(d => d.Order)
                .WithMany(p => p.OrderDetails)
                .OnDelete(DeleteBehavior.ClientNoAction)
                .HasConstraintName("FK_Order_Details_Orders");

            modelBuilder.Entity<OrderDetail>()
                .HasOne(d => d.Product)
                .WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductID)
                .OnDelete(DeleteBehavior.ClientNoAction)
                .HasConstraintName("FK_Order_Details_Products");

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
 
