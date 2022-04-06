using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
        public class Context : DbContext
        {
            public Context()
            { 
                Database.EnsureCreated();
            }
            
            public DbSet<Models.User> Users { get; set; }
            public DbSet<Models.TaskX> TaskXes { get; set; }
            public DbSet<Models.Status> Statuses { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FAQdb;Trusted_Connection=True;");
            }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<User>()
        //                .HasMany(task => task.TaskXes)
        //                .WithOne(con => con.UserSet);

        //    modelBuilder.Entity<TaskX>()
        //                .HasMany(task => task.UsersGetId)
        //                .HasForeignKey(con => con.UserSet);

        //    base.OnModelCreating(modelBuilder);
        //}

    }
}

