using DUTBites.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace DUTBites.Data
{
    public class DUTBitesDBContext : DbContext
    {
        public DUTBitesDBContext() : base("name=DUTBitesDBContext") // connection string from Web.config
        {
        }

        // Tables
        public DbSet<User> Users { get; set; }
        public DbSet<Campus> Campuses { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<DeliveryLocation> DriverLocations { get; set; }
    }
}