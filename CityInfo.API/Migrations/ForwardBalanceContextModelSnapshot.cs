﻿// <auto-generated />
using ForwardBalance.API.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ForwardBalance.API.Migrations
{
    [DbContext(typeof(ForwardBalanceContext))]
    partial class ForwardBalanceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("AccountNumber");

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
                        new { Id = 1, AccountNumber = 0, BankId = 1, Description = "System account for transfers in and out of listed accounts", IsHidden = true, Name = "Cash Account" }
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
                        new { Id = 1, IsHidden = true, Name = "System", RoutingNumber = 0 }
                    );
                });

            modelBuilder.Entity("ForwardBalance.API.Entities.Account", b =>
                {
                    b.HasOne("ForwardBalance.API.Entities.Bank", "Bank")
                        .WithMany("Accounts")
                        .HasForeignKey("BankId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
