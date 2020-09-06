using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetcore_api_sample.Models
{
    public class DbContextModel : DbContext
    {

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<users_has_roles> users_Has_roles { get; set; }

        //public DbContextModel(DbContextOptions options)
        //   : base(options)
        //{
        //    Console.WriteLine("database created ");
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=sampledb;User ID=root;password=root;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<users_has_roles>()
            //   .HasNoKey();
            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.Property(e => e.roleName).IsRequired();
            });
            modelBuilder.Entity<users_has_roles>().HasKey(sc => new { sc.UserId ,sc.RoleId,sc.roleName });

        }

    }
}
