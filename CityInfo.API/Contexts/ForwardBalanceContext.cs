using ForwardBalance.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForwardBalance.API.Contexts
{
    public class ForwardBalanceContext : DbContext
    {
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Account> Accounts { get; set; }

        public ForwardBalanceContext(DbContextOptions<ForwardBalanceContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bank>()
                .HasData(
                new Bank()
                {
                    Id = 1,
                    Name = "System",
                    RoutingNumber = 0
                });

            modelBuilder.Entity<Account>()
              .HasData(
                new Account()
                {
                    Id = 1,
                    BankId = 1,
                    AccountNumber = 0,
                    Name = "Cash Account",
                    Description = "Sytem account for transactions in/out"
                });

            base.OnModelCreating(modelBuilder);
        }

        //protected override void OnConfiguration(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("connectionstring");
        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}
