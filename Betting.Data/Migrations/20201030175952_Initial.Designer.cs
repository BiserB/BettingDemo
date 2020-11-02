﻿// <auto-generated />
using System;
using Betting.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Betting.Data.Migrations
{
    [DbContext(typeof(BettingDbContext))]
    [Migration("20201030175952_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9");

            modelBuilder.Entity("Betting.Entities.Event", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("EventName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.Property<DateTime>("EventStartDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("EventTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("TEXT");

                    b.Property<double?>("OddsForDraw")
                        .HasColumnType("REAL");

                    b.Property<double>("OddsForFirstTeam")
                        .HasColumnType("REAL");

                    b.Property<double>("OddsForSecondTeam")
                        .HasColumnType("REAL");

                    b.HasKey("EventId");

                    b.HasIndex("EventTypeId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Betting.Entities.EventType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("EventTypes");
                });

            modelBuilder.Entity("Betting.Entities.Event", b =>
                {
                    b.HasOne("Betting.Entities.EventType", "EventType")
                        .WithMany("Events")
                        .HasForeignKey("EventTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}