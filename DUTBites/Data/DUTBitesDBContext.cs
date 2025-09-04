using DUTBites.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DUTBites.Data
{
    public class DUTBitesDBContext : DbContext
    {
        public DUTBitesDBContext() : base("name=DUTBites3.0") // connection string from Web.config
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Campus> Campuses { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<DeliveryLocation> DriverLocations { get; set; }
        public DbSet<DeliveryDriver> DriverDrivers { get; set; }
      

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // One-to-Many: Campus → Stores
            modelBuilder.Entity<Campus>()
                .HasMany(c => c.Stores)
                .WithRequired(s => s.Campus)
                .HasForeignKey(s => s.CampusID)
                .WillCascadeOnDelete(false);

            // One-to-Many: Campus → Users
            modelBuilder.Entity<Campus>()
                .HasMany(c => c.Users)
                .WithRequired(u => u.Campus)
                .HasForeignKey(u => u.CampusID)
                .WillCascadeOnDelete(false);

            // One-to-Many: Store → MenuItems
            modelBuilder.Entity<Store>()
                .HasMany(s => s.MenuItems)
                .WithRequired(m => m.Store)
                .HasForeignKey(m => m.StoreID)
                .WillCascadeOnDelete(false);

            // One-to-Many: Store → Orders
            modelBuilder.Entity<Store>()
                .HasMany(s => s.Orders)
                .WithRequired(o => o.Store)
                .HasForeignKey(o => o.StoreId)
                .WillCascadeOnDelete(false);

            // One-to-Many: User → Orders
            modelBuilder.Entity<User>()
                .HasMany(u => u.Orders)
                .WithRequired(o => o.User)
                .HasForeignKey(o => o.UserId)
                .WillCascadeOnDelete(false);

            // One-to-Many: Order → OrderItems
            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderItems)
                .WithRequired(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderId)
                .WillCascadeOnDelete(false);

            // One-to-Many: MenuItem → OrderItems
            modelBuilder.Entity<MenuItem>()
                .HasMany(m => m.OrderItems)
                .WithRequired(oi => oi.MenuItem)
                .HasForeignKey(oi => oi.MenuItemId)
                .WillCascadeOnDelete(false);

            // One-to-One: Order ↔ Payment
            modelBuilder.Entity<Order>()
                .HasOptional(o => o.Payment)
                .WithRequired(p => p.Order)
                .WillCascadeOnDelete(false);

            // One-to-One: Order ↔ Delivery
            modelBuilder.Entity<Order>()
                .HasOptional(o => o.Delivery)
                .WithRequired(d => d.Order)
            .WillCascadeOnDelete(false);

            // One-to-Many: DeliveryDriver → Deliveries
            modelBuilder.Entity<DeliveryDriver>()
                .HasMany(d => d.Deliveries)
                .WithRequired(del => del.DeliveryDrivers)
                .HasForeignKey(del => del.DriverID)
                .WillCascadeOnDelete(false);

            /*One-to-Many: Delivery → DeliveryLocations
            modelBuilder.Entity<Delivery>()
                .HasMany(dd => dd.Locations)
                .WithRequired(dl => dl.Delivery)
                .HasForeignKey(dl => dl.DeliveryID)
                .WillCascadeOnDelete(false);*/
        }
    }
}