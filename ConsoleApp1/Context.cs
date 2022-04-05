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
            public DbSet<Models.TaskX> TaskX { get; set; }
        
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=FAQ;Trusted_Connection=True;");
            }
    }
}

