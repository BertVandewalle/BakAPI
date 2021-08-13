﻿// <auto-generated />
using System;
using BakAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BakAPI.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("BakAPI.Data.ApiUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

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

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("BakAPI.Data.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("ShortName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Jamaica",
                            ShortName = "JM"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Bahamas",
                            ShortName = "BS"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Cayman Island",
                            ShortName = "CI"
                        });
                });

            modelBuilder.Entity("BakAPI.Data.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("interval");

                    b.Property<int>("GreDefId")
                        .HasColumnType("integer");

                    b.Property<int>("GreDefScore")
                        .HasColumnType("integer");

                    b.Property<int>("GreOffId")
                        .HasColumnType("integer");

                    b.Property<int>("GreOffScore")
                        .HasColumnType("integer");

                    b.Property<int>("GreScore")
                        .HasColumnType("integer");

                    b.Property<int>("RedDefId")
                        .HasColumnType("integer");

                    b.Property<int>("RedDefScore")
                        .HasColumnType("integer");

                    b.Property<int>("RedOffId")
                        .HasColumnType("integer");

                    b.Property<int>("RedOffScore")
                        .HasColumnType("integer");

                    b.Property<int>("RedScore")
                        .HasColumnType("integer");

                    b.Property<DateTime>("StartDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("GreDefId");

                    b.HasIndex("GreOffId");

                    b.HasIndex("RedDefId");

                    b.HasIndex("RedOffId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("BakAPI.Data.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<int>("CountryId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<double>("Rating")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Hotels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Negril",
                            CountryId = 1,
                            Name = "Sandals Resort and Spa",
                            Rating = 4.5
                        },
                        new
                        {
                            Id = 2,
                            Address = "George Town",
                            CountryId = 3,
                            Name = "Comfort Suites",
                            Rating = 4.2999999999999998
                        },
                        new
                        {
                            Id = 3,
                            Address = "Nassua",
                            CountryId = 2,
                            Name = "Grand Palldium",
                            Rating = 4.0
                        });
                });

            modelBuilder.Entity("BakAPI.Data.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<decimal>("DefWinRate")
                        .HasColumnType("numeric");

                    b.Property<double>("Elo")
                        .HasColumnType("double precision");

                    b.Property<int>("GameAmount")
                        .HasColumnType("integer");

                    b.Property<int>("GoalAmount")
                        .HasColumnType("integer");

                    b.Property<int>("GoalAmountDef")
                        .HasColumnType("integer");

                    b.Property<int>("GoalAmountOff")
                        .HasColumnType("integer");

                    b.Property<decimal>("GoalMatchRate")
                        .HasColumnType("numeric");

                    b.Property<decimal>("GoalMatchRateDef")
                        .HasColumnType("numeric");

                    b.Property<decimal>("GoalMatchRateOff")
                        .HasColumnType("numeric");

                    b.Property<decimal>("GoalRateDef")
                        .HasColumnType("numeric");

                    b.Property<decimal>("GoalRateOff")
                        .HasColumnType("numeric");

                    b.Property<int>("GreDefAmount")
                        .HasColumnType("integer");

                    b.Property<int>("GreOffAmount")
                        .HasColumnType("integer");

                    b.Property<int>("LossAmount")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<decimal>("OffWinRate")
                        .HasColumnType("numeric");

                    b.Property<int?>("RankId")
                        .HasColumnType("integer");

                    b.Property<int>("RedDefAmount")
                        .HasColumnType("integer");

                    b.Property<int>("RedOffAmount")
                        .HasColumnType("integer");

                    b.Property<int>("WinAmount")
                        .HasColumnType("integer");

                    b.Property<int>("WinDefAmount")
                        .HasColumnType("integer");

                    b.Property<int>("WinOffAmount")
                        .HasColumnType("integer");

                    b.Property<decimal>("WinRate")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("RankId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("BakAPI.Data.Rank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Division")
                        .HasColumnType("text");

                    b.Property<int>("LowerBound")
                        .HasColumnType("integer");

                    b.Property<string>("SubDivision")
                        .HasColumnType("text");

                    b.Property<int>("UpperBound")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Ranks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Division = "Bronze",
                            LowerBound = 0,
                            SubDivision = "V",
                            UpperBound = 175
                        },
                        new
                        {
                            Id = 2,
                            Division = "Bronze",
                            LowerBound = 175,
                            SubDivision = "IV",
                            UpperBound = 350
                        },
                        new
                        {
                            Id = 3,
                            Division = "Bronze",
                            LowerBound = 350,
                            SubDivision = "III",
                            UpperBound = 525
                        },
                        new
                        {
                            Id = 4,
                            Division = "Bronze",
                            LowerBound = 525,
                            SubDivision = "II",
                            UpperBound = 700
                        },
                        new
                        {
                            Id = 5,
                            Division = "Bronze",
                            LowerBound = 700,
                            SubDivision = "I",
                            UpperBound = 875
                        },
                        new
                        {
                            Id = 6,
                            Division = "Silver",
                            LowerBound = 875,
                            SubDivision = "V",
                            UpperBound = 1050
                        },
                        new
                        {
                            Id = 7,
                            Division = "Silver",
                            LowerBound = 1050,
                            SubDivision = "IV",
                            UpperBound = 1225
                        },
                        new
                        {
                            Id = 8,
                            Division = "Silver",
                            LowerBound = 1225,
                            SubDivision = "III",
                            UpperBound = 1400
                        },
                        new
                        {
                            Id = 9,
                            Division = "Silver",
                            LowerBound = 1400,
                            SubDivision = "II",
                            UpperBound = 1575
                        },
                        new
                        {
                            Id = 10,
                            Division = "Silver",
                            LowerBound = 1575,
                            SubDivision = "I",
                            UpperBound = 1750
                        },
                        new
                        {
                            Id = 11,
                            Division = "Gold",
                            LowerBound = 1750,
                            SubDivision = "V",
                            UpperBound = 1925
                        },
                        new
                        {
                            Id = 12,
                            Division = "Gold",
                            LowerBound = 1925,
                            SubDivision = "IV",
                            UpperBound = 2100
                        },
                        new
                        {
                            Id = 13,
                            Division = "Gold",
                            LowerBound = 2100,
                            SubDivision = "III",
                            UpperBound = 2275
                        },
                        new
                        {
                            Id = 14,
                            Division = "Gold",
                            LowerBound = 2275,
                            SubDivision = "II",
                            UpperBound = 2450
                        },
                        new
                        {
                            Id = 15,
                            Division = "Gold",
                            LowerBound = 2450,
                            SubDivision = "I",
                            UpperBound = 2625
                        },
                        new
                        {
                            Id = 16,
                            Division = "Platinum",
                            LowerBound = 2625,
                            SubDivision = "V",
                            UpperBound = 2800
                        },
                        new
                        {
                            Id = 17,
                            Division = "Platinum",
                            LowerBound = 2800,
                            SubDivision = "IV",
                            UpperBound = 2975
                        },
                        new
                        {
                            Id = 18,
                            Division = "Platinum",
                            LowerBound = 2975,
                            SubDivision = "III",
                            UpperBound = 3150
                        },
                        new
                        {
                            Id = 19,
                            Division = "Platinum",
                            LowerBound = 3150,
                            SubDivision = "II",
                            UpperBound = 3325
                        },
                        new
                        {
                            Id = 20,
                            Division = "Platinum",
                            LowerBound = 3325,
                            SubDivision = "I",
                            UpperBound = 3500
                        },
                        new
                        {
                            Id = 21,
                            Division = "Diamond",
                            LowerBound = 3500,
                            SubDivision = "V",
                            UpperBound = 3675
                        },
                        new
                        {
                            Id = 22,
                            Division = "Diamond",
                            LowerBound = 3675,
                            SubDivision = "IV",
                            UpperBound = 3850
                        },
                        new
                        {
                            Id = 23,
                            Division = "Diamond",
                            LowerBound = 3850,
                            SubDivision = "III",
                            UpperBound = 4025
                        },
                        new
                        {
                            Id = 24,
                            Division = "Diamond",
                            LowerBound = 4025,
                            SubDivision = "II",
                            UpperBound = 4200
                        },
                        new
                        {
                            Id = 25,
                            Division = "Diamond",
                            LowerBound = 4200,
                            SubDivision = "I",
                            UpperBound = 4375
                        },
                        new
                        {
                            Id = 26,
                            Division = "Master",
                            LowerBound = 4375,
                            SubDivision = "V",
                            UpperBound = 4550
                        },
                        new
                        {
                            Id = 27,
                            Division = "Master",
                            LowerBound = 4550,
                            SubDivision = "IV",
                            UpperBound = 4725
                        },
                        new
                        {
                            Id = 28,
                            Division = "Master",
                            LowerBound = 4725,
                            SubDivision = "III",
                            UpperBound = 4900
                        },
                        new
                        {
                            Id = 29,
                            Division = "Master",
                            LowerBound = 4900,
                            SubDivision = "II",
                            UpperBound = 5075
                        },
                        new
                        {
                            Id = 30,
                            Division = "Master",
                            LowerBound = 5075,
                            SubDivision = "I",
                            UpperBound = 5250
                        },
                        new
                        {
                            Id = 31,
                            Division = "GrandMaster",
                            LowerBound = 5250,
                            SubDivision = "V",
                            UpperBound = 5425
                        },
                        new
                        {
                            Id = 32,
                            Division = "GrandMaster",
                            LowerBound = 5425,
                            SubDivision = "IV",
                            UpperBound = 5600
                        },
                        new
                        {
                            Id = 33,
                            Division = "GrandMaster",
                            LowerBound = 5600,
                            SubDivision = "III",
                            UpperBound = 5775
                        },
                        new
                        {
                            Id = 34,
                            Division = "GrandMaster",
                            LowerBound = 5775,
                            SubDivision = "II",
                            UpperBound = 5950
                        },
                        new
                        {
                            Id = 35,
                            Division = "GrandMaster",
                            LowerBound = 5950,
                            SubDivision = "I",
                            UpperBound = 2147483647
                        });
                });

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

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "78378eee-dd2a-4ccf-baa8-dc2e72eff066",
                            ConcurrencyStamp = "bf20a852-c01c-42ed-ac9f-1b0c7ad7396a",
                            Name = "User",
                            NormalizedName = "USER"
                        },
                        new
                        {
                            Id = "8148587b-aadf-4096-b821-21cad6200135",
                            ConcurrencyStamp = "3b2d6b41-b233-42f3-b6c0-e96167b1b0f4",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
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

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
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

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("BakAPI.Data.Game", b =>
                {
                    b.HasOne("BakAPI.Data.Player", "GreDef")
                        .WithMany("GamesGreDef")
                        .HasForeignKey("GreDefId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BakAPI.Data.Player", "GreOff")
                        .WithMany("GamesGreOff")
                        .HasForeignKey("GreOffId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BakAPI.Data.Player", "RedDef")
                        .WithMany("GamesRedDef")
                        .HasForeignKey("RedDefId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BakAPI.Data.Player", "RedOff")
                        .WithMany("GamesRedOff")
                        .HasForeignKey("RedOffId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("GreDef");

                    b.Navigation("GreOff");

                    b.Navigation("RedDef");

                    b.Navigation("RedOff");
                });

            modelBuilder.Entity("BakAPI.Data.Hotel", b =>
                {
                    b.HasOne("BakAPI.Data.Country", "Country")
                        .WithMany("Hotels")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("BakAPI.Data.Player", b =>
                {
                    b.HasOne("BakAPI.Data.Rank", "Rank")
                        .WithMany("Players")
                        .HasForeignKey("RankId");

                    b.Navigation("Rank");
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
                    b.HasOne("BakAPI.Data.ApiUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("BakAPI.Data.ApiUser", null)
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

                    b.HasOne("BakAPI.Data.ApiUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("BakAPI.Data.ApiUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BakAPI.Data.Country", b =>
                {
                    b.Navigation("Hotels");
                });

            modelBuilder.Entity("BakAPI.Data.Player", b =>
                {
                    b.Navigation("GamesGreDef");

                    b.Navigation("GamesGreOff");

                    b.Navigation("GamesRedDef");

                    b.Navigation("GamesRedOff");
                });

            modelBuilder.Entity("BakAPI.Data.Rank", b =>
                {
                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
