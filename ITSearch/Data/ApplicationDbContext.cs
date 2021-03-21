using ITSearch.Models;
using ITSearch.Models.ProductInfo;
using ITSearch.Models.ViewModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITSearch.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> applicationUsers{ get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Search> Searches { get; set; }
        public DbSet<Computer> Computers { get; set; }
        public DbSet<IOSDevice> IOSDevices { get; set; }
        public DbSet<Procedure> Procedures { get; set; }

        public DbSet<ModelNumber> ModelNumbers { get; set; }
        public DbSet<DeviceConfiguration> Configurations{ get; set; }

    }
}
