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
                    RoutingNumber = 0,
                    IsHidden = true
                });

            modelBuilder.Entity<Account>()
              .HasData(
                new Account()
                {
                    Id = 1,
                    BankId = 1,
                    AccountNumber = "0",
                    Name = "Cash Account",
                    Description = "System account for transfers in and out of listed accounts",
                    IsHidden = true
                });

            modelBuilder.Entity<Transaction>()
                .HasData(
                new Transaction()
                {
                    Id = 1,
                    Date = new DateTime(2020, 4, 26, 10, 10, 0),
                    Description = "Starting balance",
                    Amount = 0.00,
                    AccountId = 1,
                    //TransferAccountId = 1
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
