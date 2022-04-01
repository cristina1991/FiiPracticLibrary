using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.Data.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Library.Data.Entities.Context
{
    public partial class DataBaseContext : DbContext
    {
        public DataBaseContext()
        {
        }

        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer(
                    @"Server=CRISTIAN-GAMING\SQLEXPRESS;Database=LibraryDb;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationFromAssembly(typeof(DataBaseContext).Assembly);
            //this should be restrictive as the 
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
