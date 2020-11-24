using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Elkoob.Application.Common.Interfaces;
using Elkoob.Domain.Entities.CategoryAndProduct;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Elkoob.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext,IApplicationDbContext
    {
        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductToCategory> ProductToCategories { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            builder.Entity<ProductToCategory>()
                .HasKey(t => new { t.ProductId, t.CategoryId });

            builder.Entity<Item>(i =>
            {
                i.Property(w => w.Price).HasColumnType("Money");
                i.HasKey(w => w.Id);
            });


            base.OnModelCreating(builder);
        }
    }
}