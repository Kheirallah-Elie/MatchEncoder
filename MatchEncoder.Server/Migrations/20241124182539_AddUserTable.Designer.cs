﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MatchEncoder.Server.Migrations
{
    [DbContext(typeof(MatchDbContext))]
    [Migration("20241124182539_AddUserTable")]
    partial class AddUserTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Hour")
                        .HasColumnType("datetime2");

                    b.Property<int>("MatchId")
                        .HasColumnType("int");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MatchId");

                    b.HasIndex("PlayerId");

                    b.ToTable("Event");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Hour = new DateTime(2024, 11, 24, 19, 25, 38, 655, DateTimeKind.Local).AddTicks(7327),
                            MatchId = 1,
                            PlayerId = 1,
                            Points = 3,
                            Type = "Goal"
                        },
                        new
                        {
                            Id = 2,
                            Hour = new DateTime(2024, 11, 24, 19, 30, 38, 655, DateTimeKind.Local).AddTicks(7331),
                            MatchId = 1,
                            PlayerId = 2,
                            Points = 0,
                            Type = "Foul"
                        },
                        new
                        {
                            Id = 3,
                            Hour = new DateTime(2024, 11, 24, 19, 35, 38, 655, DateTimeKind.Local).AddTicks(7335),
                            MatchId = 2,
                            PlayerId = 5,
                            Points = 2,
                            Type = "Goal"
                        });
                });

            modelBuilder.Entity("Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DurationOfTimeout")
                        .HasColumnType("int");

                    b.Property<string>("EventName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("MatchDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("MatchNumber")
                        .HasColumnType("int");

                    b.Property<int?>("NumberOfQuarterTime")
                        .HasColumnType("int");

                    b.Property<int>("TeamAId")
                        .HasColumnType("int");

                    b.Property<int>("TeamBId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeamAId");

                    b.HasIndex("TeamBId");

                    b.ToTable("Match");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EventName = "Championship Finals",
                            MatchDateTime = new DateTime(2024, 12, 4, 19, 25, 38, 655, DateTimeKind.Local).AddTicks(7204),
                            MatchNumber = 0,
                            TeamAId = 1,
                            TeamBId = 2
                        },
                        new
                        {
                            Id = 2,
                            EventName = "Summer League",
                            MatchDateTime = new DateTime(2024, 12, 14, 19, 25, 38, 655, DateTimeKind.Local).AddTicks(7244),
                            MatchNumber = 0,
                            TeamAId = 3,
                            TeamBId = 4
                        });
                });

            modelBuilder.Entity("MatchPlayer", b =>
                {
                    b.Property<int>("MatchId")
                        .HasColumnType("int");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.HasKey("MatchId", "PlayerId");

                    b.HasIndex("PlayerId");

                    b.ToTable("MatchPlayer");

                    b.HasData(
                        new
                        {
                            MatchId = 1,
                            PlayerId = 1
                        },
                        new
                        {
                            MatchId = 1,
                            PlayerId = 2
                        },
                        new
                        {
                            MatchId = 1,
                            PlayerId = 3
                        },
                        new
                        {
                            MatchId = 1,
                            PlayerId = 4
                        },
                        new
                        {
                            MatchId = 2,
                            PlayerId = 5
                        },
                        new
                        {
                            MatchId = 2,
                            PlayerId = 6
                        },
                        new
                        {
                            MatchId = 2,
                            PlayerId = 7
                        },
                        new
                        {
                            MatchId = 2,
                            PlayerId = 8
                        });
                });

            modelBuilder.Entity("Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsCaptain")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Player");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsCaptain = false,
                            Name = "Alice",
                            Number = 10,
                            TeamId = 1
                        },
                        new
                        {
                            Id = 2,
                            IsCaptain = true,
                            Name = "Bob",
                            Number = 11,
                            TeamId = 1
                        },
                        new
                        {
                            Id = 3,
                            IsCaptain = false,
                            Name = "Charlie",
                            Number = 8,
                            TeamId = 2
                        },
                        new
                        {
                            Id = 4,
                            IsCaptain = false,
                            Name = "Daisy",
                            Number = 9,
                            TeamId = 2
                        },
                        new
                        {
                            Id = 5,
                            IsCaptain = true,
                            Name = "Eve",
                            Number = 15,
                            TeamId = 3
                        },
                        new
                        {
                            Id = 6,
                            IsCaptain = false,
                            Name = "Frank",
                            Number = 12,
                            TeamId = 3
                        },
                        new
                        {
                            Id = 7,
                            IsCaptain = false,
                            Name = "Grace",
                            Number = 13,
                            TeamId = 4
                        },
                        new
                        {
                            Id = 8,
                            IsCaptain = false,
                            Name = "Hank",
                            Number = 14,
                            TeamId = 4
                        });
                });

            modelBuilder.Entity("Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Team");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Team Alpha"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Team Beta"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Team Gamma"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Team Delta"
                        });
                });

            modelBuilder.Entity("User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Event", b =>
                {
                    b.HasOne("Match", "Match")
                        .WithMany("Events")
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Player", "Player")
                        .WithMany("Events")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Match");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("Match", b =>
                {
                    b.HasOne("Team", "TeamA")
                        .WithMany()
                        .HasForeignKey("TeamAId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Team", "TeamB")
                        .WithMany()
                        .HasForeignKey("TeamBId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("TeamA");

                    b.Navigation("TeamB");
                });

            modelBuilder.Entity("MatchPlayer", b =>
                {
                    b.HasOne("Match", "Match")
                        .WithMany("MatchPlayers")
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Player", "Player")
                        .WithMany("MatchPlayers")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Match");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("Player", b =>
                {
                    b.HasOne("Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("Match", b =>
                {
                    b.Navigation("Events");

                    b.Navigation("MatchPlayers");
                });

            modelBuilder.Entity("Player", b =>
                {
                    b.Navigation("Events");

                    b.Navigation("MatchPlayers");
                });

            modelBuilder.Entity("Team", b =>
                {
                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}