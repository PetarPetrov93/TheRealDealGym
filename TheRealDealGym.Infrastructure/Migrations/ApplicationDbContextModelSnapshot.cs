﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TheRealDealGym.Infrastructure.Data;

#nullable disable

namespace TheRealDealGym.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("TheRealDealGym.Infrastructure.Data.Models.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasComment("FirstName property - extension to the default User");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasComment("LastName property - extension to the default User");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasComment("This is an extension to the User. Adds FirstName and LastName properties to the User and changes the Id from string to GUID");

                    b.HasData(
                        new
                        {
                            Id = new Guid("dea12856-c198-4129-b3f3-b893d8395082"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "38677e91-e5a2-4b9f-9fe6-38f5c3befaa3",
                            Email = "FightingTrainer@trdg.com",
                            EmailConfirmed = false,
                            FirstName = "Trainer",
                            LastName = "Gae",
                            LockoutEnabled = false,
                            NormalizedEmail = "FIGHTINGTRAINER@TRDG.COM",
                            NormalizedUserName = "FIGHTINGTRAINER@TRDG.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEGsCRAnO4o5WLsqll0HdFNmdxfCjggNEJwLiTcMqXjMLZhW6+1XNCKPiOpQZfGahig==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "78f47fd7-d3d5-4fa4-bedc-e1ce253f5f6f",
                            TwoFactorEnabled = false,
                            UserName = "FightingTrainer@trdg.com"
                        },
                        new
                        {
                            Id = new Guid("c85209a1-3dec-4171-a17c-0d5203286df4"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "ed839df7-b3a9-4ee7-a778-22f5e87a9b27",
                            Email = "WaterTrainer@trdg.com",
                            EmailConfirmed = false,
                            FirstName = "Michael",
                            LastName = "Phelps",
                            LockoutEnabled = false,
                            NormalizedEmail = "WATERTRAINER@TRDG.COM",
                            NormalizedUserName = "WATERTRAINER@TRDG.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEN+HUmryY3EJWLns993laN1Nw69r997oCXNVj06qfWmiO8LVrxMsdoZfEaq3z4LaBg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "0cecaf15-dc12-427f-8118-5f537802d729",
                            TwoFactorEnabled = false,
                            UserName = "WaterTrainer@trdg.com"
                        },
                        new
                        {
                            Id = new Guid("06c362f9-c953-4507-a4ba-f53bd9e920f9"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "1db3ac6c-6dd7-4eff-8ab3-5b72d689cd9e",
                            Email = "StretchingTrainer@trdg.com",
                            EmailConfirmed = false,
                            FirstName = "Katie",
                            LastName = "Thompson",
                            LockoutEnabled = false,
                            NormalizedEmail = "STRETCHINGTRAINER@TRDG.COM",
                            NormalizedUserName = "STRETCHINGTRAINER@TRDG.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEIjoUqd6/OyJqRYFLcUNtsjMJbNUthFjyf3/H8Q0dGxO7d4OcRQNOoMqm50+OV7ZUQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "5160ac97-f58f-479a-9d26-6b1caa75bad5",
                            TwoFactorEnabled = false,
                            UserName = "StretchingTrainer@trdg.com"
                        },
                        new
                        {
                            Id = new Guid("d0e351a5-b55d-4fd0-a0f3-d011c415f5ef"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "a6807a45-a594-44a5-832a-30273bf9a74d",
                            Email = "firstGuest@trdg.com",
                            EmailConfirmed = false,
                            FirstName = "Pete",
                            LastName = "Johnson",
                            LockoutEnabled = false,
                            NormalizedEmail = "FIRSTGUEST@TRDG.COM",
                            NormalizedUserName = "FIRSTGUEST@TRDG.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEP4HAklTm+L/Ttg2hb9qAhglIbxvFJ9gfwVNvWY/ssDTBQblyYle1Rwx/2eysmuC2Q==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "e7326130-1924-49a0-9912-e1f874200182",
                            TwoFactorEnabled = false,
                            UserName = "firstGuest@trdg.com"
                        },
                        new
                        {
                            Id = new Guid("ce0dc4d9-e723-4df4-8cb0-80d8afc9122a"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "9a485611-6d5d-4520-b505-7011a0bedd26",
                            Email = "secondGuest@trdg.com",
                            EmailConfirmed = false,
                            FirstName = "Stella",
                            LastName = "Clay",
                            LockoutEnabled = false,
                            NormalizedEmail = "SECONDGUEST@TRDG.COM",
                            NormalizedUserName = "SECONDGUEST@TRDG.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAELLbCVdrv8xjMAEx/4yCkW5hIT2ksrpwiGu5z96vyXwMgFTWnXgKoTaEggvhXOENMQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "bae0779c-fe46-4361-a8b4-2e5e5b705e64",
                            TwoFactorEnabled = false,
                            UserName = "secondGuest@trdg.com"
                        });
                });

            modelBuilder.Entity("TheRealDealGym.Infrastructure.Data.Models.Booking", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Booking identifier");

                    b.Property<Guid>("ClassId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Foreign key to Class");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasComment("Serves a soft delete purpose");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Foreign key to ApplicationUser");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("UserId");

                    b.ToTable("Bookings");

                    b.HasComment("Many bookings by different users can be made for one Class. One User can have many bookings for different classes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("2283428d-0ed0-4837-9bb2-028485808ac5"),
                            ClassId = new Guid("86cc93b0-3993-4a88-b41c-c0414538c7f4"),
                            IsDeleted = false,
                            UserId = new Guid("d0e351a5-b55d-4fd0-a0f3-d011c415f5ef")
                        });
                });

            modelBuilder.Entity("TheRealDealGym.Infrastructure.Data.Models.Class", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Class identifier");

                    b.Property<DateTime>("DateAndTime")
                        .HasColumnType("datetime2")
                        .HasComment("Starting date and time of the class");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)")
                        .HasComment("Description and additional info about the class");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasComment("Serves a soft delete purpose");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)")
                        .HasComment("The price of the class");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Foreign key to Room");

                    b.Property<Guid>("SportId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Foreign key to Sport");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasComment("The title of the class");

                    b.Property<Guid>("TrainerId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Foreign key to Trainer");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.HasIndex("SportId");

                    b.HasIndex("TrainerId");

                    b.ToTable("Classes");

                    b.HasComment("The Class entity stores information about a specific class");

                    b.HasData(
                        new
                        {
                            Id = new Guid("86cc93b0-3993-4a88-b41c-c0414538c7f4"),
                            DateAndTime = new DateTime(2025, 10, 5, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "This is a Muay Thai class suitable for beginners.",
                            IsDeleted = false,
                            Price = 15m,
                            RoomId = new Guid("3db85752-7746-4d29-a638-5a54c2e07075"),
                            SportId = new Guid("28b80b07-87c8-42f7-9af6-28d832ce7b2b"),
                            Title = "Muay Thai for beginners",
                            TrainerId = new Guid("966d1ddc-b505-4aae-b790-595a4c688931")
                        },
                        new
                        {
                            Id = new Guid("6a05950a-e1bf-4b6c-9577-2c289c3e6de6"),
                            DateAndTime = new DateTime(2025, 9, 22, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "This is a swimming class for children only.",
                            IsDeleted = false,
                            Price = 10m,
                            RoomId = new Guid("70e053fc-61a0-4ab7-9104-08572c23aa38"),
                            SportId = new Guid("7e20cc5c-6c1b-4ba6-a070-517660fead98"),
                            Title = "Swimming for kids",
                            TrainerId = new Guid("3c944adc-2b2b-4e81-a643-643fcb116262")
                        },
                        new
                        {
                            Id = new Guid("7a90a874-0c11-4e70-9391-cc3487e60b0e"),
                            DateAndTime = new DateTime(2025, 3, 3, 13, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "This is a Yoga class suitable experienced people with at least 1 year of experience in yoga/stretching.",
                            IsDeleted = false,
                            Price = 14m,
                            RoomId = new Guid("d88e930f-8694-4c04-a58a-ca71373b6c22"),
                            SportId = new Guid("890d3966-eb5e-42f1-97e2-79382ce3ac96"),
                            Title = "Yoga Advanced",
                            TrainerId = new Guid("62cf1550-e01e-452b-9fe4-95487b14514e")
                        });
                });

            modelBuilder.Entity("TheRealDealGym.Infrastructure.Data.Models.Room", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Room identifier");

                    b.Property<int>("Capacity")
                        .HasColumnType("int")
                        .HasComment("The maximum capacity of the room");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasComment("Serves a soft delete purpose");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasComment("The name of the room");

                    b.HasKey("Id");

                    b.ToTable("Rooms");

                    b.HasComment("The room is the place where a specific type of classes will be taking place.");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3db85752-7746-4d29-a638-5a54c2e07075"),
                            Capacity = 50,
                            IsDeleted = false,
                            Name = "Fighting room"
                        },
                        new
                        {
                            Id = new Guid("70e053fc-61a0-4ab7-9104-08572c23aa38"),
                            Capacity = 40,
                            IsDeleted = false,
                            Name = "Pool"
                        },
                        new
                        {
                            Id = new Guid("d88e930f-8694-4c04-a58a-ca71373b6c22"),
                            Capacity = 1,
                            IsDeleted = false,
                            Name = "Open Space room"
                        });
                });

            modelBuilder.Entity("TheRealDealGym.Infrastructure.Data.Models.Sport", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Sport identifier");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasComment("The category of the sport");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasComment("Serves a soft delete purpose");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasComment("The title of the sport");

                    b.HasKey("Id");

                    b.ToTable("Sports");

                    b.HasComment("The Sport holds the title of a given sport and its category (type of sport)");

                    b.HasData(
                        new
                        {
                            Id = new Guid("28b80b07-87c8-42f7-9af6-28d832ce7b2b"),
                            Category = "FightingSports",
                            IsDeleted = false,
                            Title = "MuayThai"
                        },
                        new
                        {
                            Id = new Guid("7e20cc5c-6c1b-4ba6-a070-517660fead98"),
                            Category = "WaterSports",
                            IsDeleted = false,
                            Title = "Swimming"
                        },
                        new
                        {
                            Id = new Guid("890d3966-eb5e-42f1-97e2-79382ce3ac96"),
                            Category = "Stretching",
                            IsDeleted = false,
                            Title = "Yoga"
                        });
                });

            modelBuilder.Entity("TheRealDealGym.Infrastructure.Data.Models.Trainer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Trainer identifier");

                    b.Property<int>("Age")
                        .HasColumnType("int")
                        .HasComment("Trainer's age");

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)")
                        .HasComment("More information about the trainer (Biography)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasComment("Serves a soft delete purpose");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Foreign key to ApplicationUser");

                    b.Property<int>("YearsOfExperience")
                        .HasColumnType("int")
                        .HasComment("Trainer's years of experience.");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Trainers");

                    b.HasComment("Trainer can organize classes and teach all the Sports which he is qualified to teach");

                    b.HasData(
                        new
                        {
                            Id = new Guid("966d1ddc-b505-4aae-b790-595a4c688931"),
                            Age = 51,
                            Bio = "I am one of the best MyaiThai coaches in the world",
                            IsDeleted = false,
                            UserId = new Guid("dea12856-c198-4129-b3f3-b893d8395082"),
                            YearsOfExperience = 25
                        },
                        new
                        {
                            Id = new Guid("3c944adc-2b2b-4e81-a643-643fcb116262"),
                            Age = 40,
                            Bio = "I am one of the best swimmers in the world",
                            IsDeleted = false,
                            UserId = new Guid("c85209a1-3dec-4171-a17c-0d5203286df4"),
                            YearsOfExperience = 19
                        },
                        new
                        {
                            Id = new Guid("62cf1550-e01e-452b-9fe4-95487b14514e"),
                            Age = 24,
                            Bio = "I am very positive person and great professional.",
                            IsDeleted = false,
                            UserId = new Guid("06c362f9-c953-4507-a4ba-f53bd9e920f9"),
                            YearsOfExperience = 3
                        });
                });

            modelBuilder.Entity("TheRealDealGym.Infrastructure.Data.Models.TrainerSport", b =>
                {
                    b.Property<Guid>("TrainerId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Trainer identifier");

                    b.Property<Guid>("SportId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Sport identifier");

                    b.HasKey("TrainerId", "SportId");

                    b.HasIndex("SportId");

                    b.ToTable("TrainersSports");

                    b.HasComment("Mapping the Trainer and Sport entities");

                    b.HasData(
                        new
                        {
                            TrainerId = new Guid("966d1ddc-b505-4aae-b790-595a4c688931"),
                            SportId = new Guid("28b80b07-87c8-42f7-9af6-28d832ce7b2b")
                        },
                        new
                        {
                            TrainerId = new Guid("3c944adc-2b2b-4e81-a643-643fcb116262"),
                            SportId = new Guid("7e20cc5c-6c1b-4ba6-a070-517660fead98")
                        },
                        new
                        {
                            TrainerId = new Guid("62cf1550-e01e-452b-9fe4-95487b14514e"),
                            SportId = new Guid("890d3966-eb5e-42f1-97e2-79382ce3ac96")
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("TheRealDealGym.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("TheRealDealGym.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TheRealDealGym.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("TheRealDealGym.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TheRealDealGym.Infrastructure.Data.Models.Booking", b =>
                {
                    b.HasOne("TheRealDealGym.Infrastructure.Data.Models.Class", "Class")
                        .WithMany("Bookings")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TheRealDealGym.Infrastructure.Data.Models.ApplicationUser", "User")
                        .WithMany("Bookings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TheRealDealGym.Infrastructure.Data.Models.Class", b =>
                {
                    b.HasOne("TheRealDealGym.Infrastructure.Data.Models.Room", "Room")
                        .WithMany("Classes")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TheRealDealGym.Infrastructure.Data.Models.Sport", "Sport")
                        .WithMany("Classes")
                        .HasForeignKey("SportId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TheRealDealGym.Infrastructure.Data.Models.Trainer", "Trainer")
                        .WithMany("Classes")
                        .HasForeignKey("TrainerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Room");

                    b.Navigation("Sport");

                    b.Navigation("Trainer");
                });

            modelBuilder.Entity("TheRealDealGym.Infrastructure.Data.Models.Trainer", b =>
                {
                    b.HasOne("TheRealDealGym.Infrastructure.Data.Models.ApplicationUser", "User")
                        .WithOne("Trainer")
                        .HasForeignKey("TheRealDealGym.Infrastructure.Data.Models.Trainer", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TheRealDealGym.Infrastructure.Data.Models.TrainerSport", b =>
                {
                    b.HasOne("TheRealDealGym.Infrastructure.Data.Models.Sport", "Sport")
                        .WithMany("TrainersSports")
                        .HasForeignKey("SportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TheRealDealGym.Infrastructure.Data.Models.Trainer", "Trainer")
                        .WithMany("TrainersSports")
                        .HasForeignKey("TrainerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sport");

                    b.Navigation("Trainer");
                });

            modelBuilder.Entity("TheRealDealGym.Infrastructure.Data.Models.ApplicationUser", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("Trainer");
                });

            modelBuilder.Entity("TheRealDealGym.Infrastructure.Data.Models.Class", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("TheRealDealGym.Infrastructure.Data.Models.Room", b =>
                {
                    b.Navigation("Classes");
                });

            modelBuilder.Entity("TheRealDealGym.Infrastructure.Data.Models.Sport", b =>
                {
                    b.Navigation("Classes");

                    b.Navigation("TrainersSports");
                });

            modelBuilder.Entity("TheRealDealGym.Infrastructure.Data.Models.Trainer", b =>
                {
                    b.Navigation("Classes");

                    b.Navigation("TrainersSports");
                });
#pragma warning restore 612, 618
        }
    }
}
