using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TireDep.Domain.Model;

namespace TireDep.Infrastructure
{
    public class Context : IdentityDbContext
    {

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Deposit> Deposits { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<SeasonTire> SeasonTires { get; set; }
        public Context(DbContextOptions options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            

            // relacja 1:1
            builder.Entity<Owner>()
                .HasOne(a => a.Contact).WithOne(b => b.Owner)
                .HasForeignKey<Contact>(k => k.OwnerRef);

            //relacja wiele do wielu - brak
            //seed
            var a = builder.Entity<SeasonTire>().HasData(
                new SeasonTire
                {
                    Id = 1,
                    Name = "Summer"
                },
                new SeasonTire
                {
                    Id = 2,
                    Name = "Winter"
                },
                new SeasonTire
                {
                    Id = 3,
                    Name = "All Season"
                }
            );
            base.OnModelCreating(builder);
        }
    }
}
