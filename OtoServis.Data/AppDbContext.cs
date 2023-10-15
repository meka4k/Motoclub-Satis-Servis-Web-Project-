using Microsoft.EntityFrameworkCore;
using OtoServis.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServis.Data
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-HGACH0N;Initial Catalog=AracSatisDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Contact> Contacts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Roles>().Property(x => x.Name).IsRequired().HasColumnType("varchar(50)");
            modelBuilder.Entity<Brand>().Property(x => x.Name).IsRequired().HasColumnType("varchar(50)");

            modelBuilder.Entity<Roles>().HasData(new Roles
            {
                Id = 1,
                Name = "admin"
            });


            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                Name = "admin",
                Surname = "admin",
                Phone = "0530",
                IsActive = true,
                CreatedDate = DateTime.Now,
                Email = "admin@gmail.com",
                Username = "admin",
                Password = "12345",
                //Roles=new Roles { Id=1},
                RolesId = 1,

            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
