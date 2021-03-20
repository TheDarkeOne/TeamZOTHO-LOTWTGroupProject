﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TeamZealzamorpheoftheHoliestOrder_LordsoftheWesternTerritories.Services;

namespace TeamZealzamorpheoftheHoliestOrder_LordsoftheWesternTerritories.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("CategoryStoreItem", b =>
                {
                    b.Property<int>("CategoriesId")
                        .HasColumnType("integer");

                    b.Property<int>("StoreItemsId")
                        .HasColumnType("integer");

                    b.HasKey("CategoriesId", "StoreItemsId");

                    b.HasIndex("StoreItemsId");

                    b.ToTable("CategoryStoreItem");
                });

            modelBuilder.Entity("TeamZ.Shared.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("TeamZ.Shared.LogMessage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Action")
                        .HasColumnType("text");

                    b.Property<string>("Level")
                        .HasColumnType("text");

                    b.Property<string>("Parameters")
                        .HasColumnType("text");

                    b.Property<string>("Service")
                        .HasColumnType("text");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("LogMessages");
                });

            modelBuilder.Entity("TeamZ.Shared.StoreItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("ItemName")
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("StoreItems");
                });

            modelBuilder.Entity("TeamZ.Shared.StoreTransaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int?>("ItemId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("TeamZ.Shared.StoreUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CategoryStoreItem", b =>
                {
                    b.HasOne("TeamZ.Shared.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TeamZ.Shared.StoreItem", null)
                        .WithMany()
                        .HasForeignKey("StoreItemsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TeamZ.Shared.StoreTransaction", b =>
                {
                    b.HasOne("TeamZ.Shared.StoreItem", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId");

                    b.Navigation("Item");
                });
#pragma warning restore 612, 618
        }
    }
}
