﻿using ForwardBalance.API.Entities;
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
        public DbSet<Entry> Entries { get; set; }

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
                    Name = "System Account",
                    Description = "System account for transfers in and out of listed accounts",
                    IsHidden = true
                });

            modelBuilder.Entity<Entry>()
                .HasData(
                new Entry()
                {
                    Id = 1,
                    Date = new DateTime(2020, 4, 26, 10, 10, 0),
                    Description = "Starting balance",
                    Amount = 0.00,
                    AccountId = 1
                });

            modelBuilder.Entity<Entry>()
                .HasData(
                new Entry()
                {
                    Id = 100,
                    Date = new DateTime(2020, 4, 27, 0, 0, 0),
                    Description = "Deposit",
                    Amount = 10.00,
                    AccountId = 4
                });

            modelBuilder.Entity<Entry>()
                .HasData(
                new Entry()
                {
                    Id = 101,
                    Date = new DateTime(2020, 4, 27, 0, 0, 0),
                    Description = "Deposit",
                    Amount = -10.00,
                    AccountId = 1
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
