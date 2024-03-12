﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RentH2.Services.AuthAPI.Data;

#nullable disable

namespace RentH2.Services.AuthAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240312023601_addAlternateKeyUserTable4")]
    partial class addAlternateKeyUserTable4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "cac43a6e-f7bb-4448-baaf-ladd431ccbbf",
                            Name = "Administrador",
                            NormalizedName = "ADMINISTRADOR"
                        },
                        new
                        {
                            Id = "cac43a7e-f7cb-4448-baaf-labb431eabbf",
                            Name = "Entregador",
                            NormalizedName = "ENTREGADOR"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "408aa945-3d84-4421-8342-7269ec64d949",
                            RoleId = "cac43a6e-f7bb-4448-baaf-ladd431ccbbf"
                        },
                        new
                        {
                            UserId = "208aa945-2d84-2421-2342-2269ec64d949",
                            RoleId = "cac43a7e-f7cb-4448-baaf-labb431eabbf"
                        },
                        new
                        {
                            UserId = "208dd945-2d84-2421-2342-2269fc54d949",
                            RoleId = "cac43a7e-f7cb-4448-baaf-labb431eabbf"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("RentH2.Services.AuthAPI.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<DateTime>("DateBirth")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("DocumentId")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("DriverLicenseClass")
                        .HasColumnType("text");

                    b.Property<string>("DriverLicenseId")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("DriverLicenseImageLocalPath")
                        .HasColumnType("text");

                    b.Property<string>("DriverLicenseImageUrl")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<string>("SurName")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasAlternateKey("DocumentId");

                    b.HasAlternateKey("DriverLicenseId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "408aa945-3d84-4421-8342-7269ec64d949",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "8396e1c5-1297-42b3-b38e-52167a2e16a5",
                            DateBirth = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DocumentId = "5ABFFEAAEAE0",
                            DriverLicenseClass = "A+B",
                            DriverLicenseId = "6D13ED6A-957A-4F94",
                            DriverLicenseImageLocalPath = "",
                            DriverLicenseImageUrl = "",
                            Email = "admin@renth2.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            Name = "System",
                            NormalizedEmail = "ADMIN@RENTH2.COM",
                            NormalizedUserName = "ADMIN@RENTH2.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEG93kx3safkO5X2wD8GBv0RSbqFhdRKi09DCZ8ZTh8CFW7IRfVGNEk+XkfZ5aqkGZA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "dc46e1b6-045f-4c8c-a5c1-ebff03cf4092",
                            SurName = "Admin",
                            TwoFactorEnabled = false,
                            UserName = "admin@renth2.com"
                        },
                        new
                        {
                            Id = "208aa945-2d84-2421-2342-2269ec64d949",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "c61bd860-72f1-422d-a1c3-2a0178ad9f18",
                            DateBirth = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DocumentId = "7AA4F3857AB9",
                            DriverLicenseClass = "B",
                            DriverLicenseId = "C5239363-957A-4F94",
                            DriverLicenseImageLocalPath = "",
                            DriverLicenseImageUrl = "",
                            Email = "rider@renth2.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            Name = "System",
                            NormalizedEmail = "RIDER@RENTH2.COM",
                            NormalizedUserName = "RIDER@RENTH2.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEDakk8Y/HNiAb0bs6Crnt4lelE8t67QHOzN4rl79yWvUnPry3Z7woPDw2AOEdMe7uA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "7adf0bf2-dd0b-414f-9e8f-c31916618bc7",
                            SurName = "Rider",
                            TwoFactorEnabled = false,
                            UserName = "rider@renth2.com"
                        },
                        new
                        {
                            Id = "208dd945-2d84-2421-2342-2269fc54d949",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "e82372e7-9930-482d-9e4a-35d9b8d7d322",
                            DateBirth = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DocumentId = "8BB4F3857AC0",
                            DriverLicenseClass = "B",
                            DriverLicenseId = "D5239773-4F94-957A",
                            DriverLicenseImageLocalPath = "",
                            DriverLicenseImageUrl = "",
                            Email = "rider02@renth2.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            Name = "System",
                            NormalizedEmail = "RIDER02@RENTH2.COM",
                            NormalizedUserName = "RIDER02@RENTH2.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEAFD7nUe9ZdImpSl3RxpFqFMASHqfcSQFICgouJMRSzRLVy2uoImvvg+IRFUzXv79g==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "1625eb2b-cc39-4c8b-ac87-51ece94a3085",
                            SurName = "Rider02",
                            TwoFactorEnabled = false,
                            UserName = "rider02@renth2.com"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("RentH2.Services.AuthAPI.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("RentH2.Services.AuthAPI.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RentH2.Services.AuthAPI.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("RentH2.Services.AuthAPI.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}