using Array.Core.Models;
using Array.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace Array.Repository.DatabaseContextLayer
{
    public class ArrayDbContext : DbContext
    {
        public ArrayDbContext()
        {
        }
        public ArrayDbContext(DbContextOptions<ArrayDbContext> options):base(options)
        {
        }
        public DbSet<Idea> Ideas { get; set; }
        public DbSet<User> Users { get; set; } 
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if(!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["ArrayDB"].ConnectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
