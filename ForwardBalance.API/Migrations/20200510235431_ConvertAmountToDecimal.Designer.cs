﻿// <auto-generated />
using System;
using ForwardBalance.API.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ForwardBalance.API.Migrations
{
    [DbContext(typeof(ForwardBalanceContext))]
    [Migration("20200510235431_ConvertAmountToDecimal")]
    partial class ConvertAmountToDecimal
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ForwardBalance.API.Entities.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountNumber")
                        .HasMaxLength(20);

                    b.Property<int>("BankId");

                    b.Property<string>("Description")
                        .HasMaxLength(200);

                    b.Property<bool>("IsHidden");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("BankId");

                    b.ToTable("Accounts");

                    b.HasData(
                        new { Id = 1, AccountNumber = "0", BankId = 1, Description = "System account for transfers in and out of listed accounts", IsHidden = true, Name = "System Account" },
                        new { Id = 2, AccountNumber = "A1", BankId = 2, Description = "This is a test checking account for Test Bank A", IsHidden = false, Name = "Test Checking Account" },
                        new { Id = 3, AccountNumber = "A2", BankId = 2, Description = "This is a test savings account for Test Bank A", IsHidden = false, Name = "Test Savings Account" },
                        new { Id = 4, AccountNumber = "B1", BankId = 3, Description = "This is a test checking account for Test Bank B", IsHidden = false, Name = "Test Checking Account" },
                        new { Id = 5, AccountNumber = "B2", BankId = 3, Description = "This is a test savings account for Test Bank B", IsHidden = false, Name = "Test Savings Account" }
                    );
                });

            modelBuilder.Entity("ForwardBalance.API.Entities.Bank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsHidden");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("RoutingNumber");

                    b.HasKey("Id");

                    b.ToTable("Banks");

                    b.HasData(
                        new { Id = 1, IsHidden = true, Name = "System", RoutingNumber = 0 },
                        new { Id = 2, IsHidden = false, Name = "Test Bank A", RoutingNumber = 11111 },
                        new { Id = 3, IsHidden = false, Name = "Test Bank B", RoutingNumber = 22222 }
                    );
                });

            modelBuilder.Entity("ForwardBalance.API.Entities.Entry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountId");

                    b.Property<decimal>("Amount");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("RelatedEntryId");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Entries");
                });

            modelBuilder.Entity("ForwardBalance.API.Entities.Account", b =>
                {
                    b.HasOne("ForwardBalance.API.Entities.Bank", "Bank")
                        .WithMany("Accounts")
                        .HasForeignKey("BankId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ForwardBalance.API.Entities.Entry", b =>
                {
                    b.HasOne("ForwardBalance.API.Entities.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}