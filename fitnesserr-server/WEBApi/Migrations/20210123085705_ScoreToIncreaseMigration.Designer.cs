﻿// <auto-generated />
using System;
using Core.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace WEBApi.Migrations
{
    [DbContext(typeof(TrainingContext))]
    [Migration("20210123085705_ScoreToIncreaseMigration")]
    partial class ScoreToIncreaseMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Core.Entities.Exercise", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(500)");

                    b.Property<string>("ImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<int>("ScoreToIncrease")
                        .HasColumnType("int");

                    b.Property<int>("TimeToComplete")
                        .HasColumnType("int");

                    b.Property<int>("Times")
                        .HasColumnType("int");

                    b.Property<Guid>("TrainingId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TrainingId");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("Core.Entities.Training", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DatePublished")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(500)");

                    b.Property<bool>("IsPublic")
                        .HasColumnType("bit");

                    b.Property<int>("Likes")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Type")
                        .HasColumnType("varchar(100)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Trainings");
                });

            modelBuilder.Entity("Core.Entities.TrainingDone", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateDone")
                        .HasColumnType("datetime2");

                    b.Property<int>("TimeDone")
                        .HasColumnType("int");

                    b.Property<Guid>("TrainingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("TrainingDone");
                });

            modelBuilder.Entity("Core.Entities.TrainingProgram", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsPublic")
                        .HasColumnType("bit");

                    b.Property<Guid>("TrainingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("TrainingPrograms");
                });

            modelBuilder.Entity("Core.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(400)");

                    b.Property<string>("LastName")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Core.Entities.Exercise", b =>
                {
                    b.HasOne("Core.Entities.Training", null)
                        .WithMany("Exercises")
                        .HasForeignKey("TrainingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Entities.TrainingDone", b =>
                {
                    b.HasOne("Core.Entities.User", null)
                        .WithMany("TrainingDones")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Entities.TrainingProgram", b =>
                {
                    b.HasOne("Core.Entities.User", null)
                        .WithMany("TrainingPrograms")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Entities.Training", b =>
                {
                    b.Navigation("Exercises");
                });

            modelBuilder.Entity("Core.Entities.User", b =>
                {
                    b.Navigation("TrainingDones");

                    b.Navigation("TrainingPrograms");
                });
#pragma warning restore 612, 618
        }
    }
}
