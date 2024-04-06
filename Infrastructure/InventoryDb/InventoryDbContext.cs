﻿using Domain.BaseDomain.DomainModels;
using Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserEntityTypeConfiguration());

            // Applying global query filter to which entity has dervied ISoftDelete interface
            builder.ApplySoftDeleteQueryFilter();
        }

        public DbSet<LoginUser> LoginUser { get; set; }
    }
}
