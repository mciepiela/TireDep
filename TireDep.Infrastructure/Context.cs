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
            base.OnModelCreating(builder);

            // relacja 1:1
            builder.Entity<Owner>()
                .HasOne(a => a.Contact).WithOne(b => b.Owner)
                .HasForeignKey<Contact>(k => k.OwnerRef);

            //relacja wiele do wielu - brak

        }

    }
}
