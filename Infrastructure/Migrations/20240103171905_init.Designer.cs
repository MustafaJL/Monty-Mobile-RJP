﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240103171905_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.MobileDataPlan", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<decimal>("PricePerMonth")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("MobileDataPlans");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedDate = new DateTime(2024, 1, 3, 19, 19, 5, 283, DateTimeKind.Utc).AddTicks(6385),
                            Description = "2GB for anghami",
                            Name = "Anghami",
                            PricePerMonth = 10m
                        },
                        new
                        {
                            Id = 2L,
                            CreatedDate = new DateTime(2024, 1, 3, 19, 19, 5, 283, DateTimeKind.Utc).AddTicks(6397),
                            Description = "60 min talking, 3Gb Mobile Data",
                            Name = "Web & Talk",
                            PricePerMonth = 20m
                        },
                        new
                        {
                            Id = 3L,
                            CreatedDate = new DateTime(2024, 1, 3, 19, 19, 5, 283, DateTimeKind.Utc).AddTicks(6398),
                            Description = "6GB Mobile Data",
                            Name = "Hs3",
                            PricePerMonth = 30m
                        });
                });

            modelBuilder.Entity("Domain.Entities.Subscription", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<decimal>("Cost")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("MobileDataPlanId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("MobileDataPlanId");

                    b.HasIndex("UserId");

                    b.ToTable("Subscriptions");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("LastName")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<bool>("isAdmin")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedDate = new DateTime(2024, 1, 3, 19, 19, 5, 283, DateTimeKind.Utc).AddTicks(6997),
                            Email = "admin@monty.com",
                            FirstName = "admin",
                            LastName = "admin",
                            Password = "mgjLOOyDs6fRsf94geNGIvSNk/ugZ+XstJZ0qqyMR3KG7xfEv2rd865kgsk4GqoJCCoTP7GFmBJICvJn1DaiDA==",
                            PhoneNumber = "01000000",
                            Salt = "Vkv4EVK21YeHqJ2xumfXsKMdOe2o0smoG4g+5Q+xKT55CHU8Gm6f2msoT+B7XdfzTUPFx3cIVa4PlOMq+iQrv+6kHRhuvWdwIv/31YtOgY2bfshFskuFzklqBiaygshnUb7NrwwwdhJcaGLcMHQ7L9RW7cKjgAbHABRUWxsm4eU=",
                            Username = "admin",
                            isAdmin = true
                        });
                });

            modelBuilder.Entity("Domain.Entities.Subscription", b =>
                {
                    b.HasOne("Domain.Entities.MobileDataPlan", "MobileDataPlan")
                        .WithMany()
                        .HasForeignKey("MobileDataPlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MobileDataPlan");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}