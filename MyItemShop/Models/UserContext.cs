using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyItemShop.Models;

namespace MyItemShop.Models
{
    public class UserContext:DbContext 
    {
        public UserContext(DbContextOptions<UserContext> options):base(options)
        {
            
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Cart> Cart { get; set; }

      //  public DbSet<CartDTO> CartDTO { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
            .HasOne(p => p.User)
            .WithMany(b => b.Orders)
            .HasForeignKey(p => p.UserID);
            modelBuilder.Entity<Order>().HasKey(o => o.UserID);
            

            modelBuilder.Entity<OrderedItem>().HasKey(o => new { o.ItemID, o.DateOfPurchase });
            

            modelBuilder.Entity<Cart>()
                .HasOne(p => p.User)
                .WithMany(b => b.CartItems)
                .HasForeignKey(p => p.UserID);
            modelBuilder.Entity<Cart>().HasKey(o => o.UserID);

            modelBuilder.Entity<CartItem>().HasKey(o => new { o.ItemID });

            modelBuilder.Entity<CartItem>().Property(e => e.ItemID).ValueGeneratedNever();

         //  modelBuilder.Entity<CartDTO>().HasKey(o => new { o.UserID }) ;
            
        }

        public DbSet<MyItemShop.Models.CartItem> CartItem { get; set; }

        public DbSet<MyItemShop.Models.OrderedItem> OrderedItem { get; set; }


        
       
        
     
    }
}
