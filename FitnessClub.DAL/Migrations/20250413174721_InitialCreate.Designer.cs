﻿// <auto-generated />
using System;
using FitnessClub.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FitnessClub.DAL.Migrations
{
    [DbContext(typeof(FitnessClubContext))]
    [Migration("20250413174721_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.4");

            modelBuilder.Entity("FitnessClub.DAL.Models.ClassSession", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Capacity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClubId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("SessionDateTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ClubId");

                    b.ToTable("ClassSessions");
                });

            modelBuilder.Entity("FitnessClub.DAL.Models.Club", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Clubs");
                });

            modelBuilder.Entity("FitnessClub.DAL.Models.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("FitnessClub.DAL.Models.MembershipCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("CardType")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MemberId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("MemberId")
                        .IsUnique();

                    b.ToTable("MembershipCards");
                });

            modelBuilder.Entity("FitnessClub.DAL.Models.Visit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClassSessionId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MembershipCardId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("VisitDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ClassSessionId");

                    b.HasIndex("MembershipCardId");

                    b.ToTable("Visits");
                });

            modelBuilder.Entity("FitnessClub.DAL.Models.ClassSession", b =>
                {
                    b.HasOne("FitnessClub.DAL.Models.Club", "Club")
                        .WithMany("Sessions")
                        .HasForeignKey("ClubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Club");
                });

            modelBuilder.Entity("FitnessClub.DAL.Models.MembershipCard", b =>
                {
                    b.HasOne("FitnessClub.DAL.Models.Member", "Member")
                        .WithOne("MembershipCard")
                        .HasForeignKey("FitnessClub.DAL.Models.MembershipCard", "MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");
                });

            modelBuilder.Entity("FitnessClub.DAL.Models.Visit", b =>
                {
                    b.HasOne("FitnessClub.DAL.Models.ClassSession", "ClassSession")
                        .WithMany("Visits")
                        .HasForeignKey("ClassSessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitnessClub.DAL.Models.MembershipCard", "MembershipCard")
                        .WithMany("Visits")
                        .HasForeignKey("MembershipCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClassSession");

                    b.Navigation("MembershipCard");
                });

            modelBuilder.Entity("FitnessClub.DAL.Models.ClassSession", b =>
                {
                    b.Navigation("Visits");
                });

            modelBuilder.Entity("FitnessClub.DAL.Models.Club", b =>
                {
                    b.Navigation("Sessions");
                });

            modelBuilder.Entity("FitnessClub.DAL.Models.Member", b =>
                {
                    b.Navigation("MembershipCard")
                        .IsRequired();
                });

            modelBuilder.Entity("FitnessClub.DAL.Models.MembershipCard", b =>
                {
                    b.Navigation("Visits");
                });
#pragma warning restore 612, 618
        }
    }
}
