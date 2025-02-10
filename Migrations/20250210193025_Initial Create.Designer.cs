﻿// <auto-generated />
using System;
using DMS_Audit_MVC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DMS_Audit_MVC.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250210193025_Initial Create")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.1");

            modelBuilder.Entity("DMS_Audit_MVC.Models.Criteria", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("TEXT");

                    b.Property<string>("Group")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Criterias");
                });

            modelBuilder.Entity("DMS_Audit_MVC.Models.CriteriaState", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Closed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClosedBy")
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ClosedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClosingComment")
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<string>("Comment")
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<int>("CriteriaID")
                        .HasColumnType("INTEGER");

                    b.Property<short>("CurrentLvl")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("TEXT");

                    b.Property<byte>("Month")
                        .HasColumnType("INTEGER");

                    b.Property<float>("Progress")
                        .HasColumnType("REAL");

                    b.Property<short>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("CriteriaID");

                    b.ToTable("CriteriaStates");
                });

            modelBuilder.Entity("DMS_Audit_MVC.Models.Level", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CriteriaID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<short>("Level_")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CriteriaID");

                    b.ToTable("Levels");
                });

            modelBuilder.Entity("DMS_Audit_MVC.Models.LevelState", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comment")
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<int>("LevelId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.Property<byte>("Month")
                        .HasColumnType("INTEGER");

                    b.Property<short>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("LevelId");

                    b.ToTable("LevelStates");
                });

            modelBuilder.Entity("DMS_Audit_MVC.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AddedBy")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("AmAzon")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<bool>("Deleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("DeletedBy")
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("LevelId")
                        .HasColumnType("INTEGER");

                    b.Property<short>("State")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("LevelId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("DMS_Audit_MVC.Models.CriteriaState", b =>
                {
                    b.HasOne("DMS_Audit_MVC.Models.Criteria", "Criteria")
                        .WithMany()
                        .HasForeignKey("CriteriaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Criteria");
                });

            modelBuilder.Entity("DMS_Audit_MVC.Models.Level", b =>
                {
                    b.HasOne("DMS_Audit_MVC.Models.Criteria", "Criteria")
                        .WithMany()
                        .HasForeignKey("CriteriaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Criteria");
                });

            modelBuilder.Entity("DMS_Audit_MVC.Models.LevelState", b =>
                {
                    b.HasOne("DMS_Audit_MVC.Models.Level", "Level")
                        .WithMany()
                        .HasForeignKey("LevelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Level");
                });

            modelBuilder.Entity("DMS_Audit_MVC.Models.Project", b =>
                {
                    b.HasOne("DMS_Audit_MVC.Models.Level", "Level")
                        .WithMany()
                        .HasForeignKey("LevelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Level");
                });
#pragma warning restore 612, 618
        }
    }
}
