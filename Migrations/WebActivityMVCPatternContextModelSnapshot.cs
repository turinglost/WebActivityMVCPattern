﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebActivityMVCPattern.Data;

#nullable disable

namespace WebActivityMVCPattern.Migrations
{
    [DbContext(typeof(WebActivityMVCPatternContext))]
    partial class WebActivityMVCPatternContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebActivityMVCPattern.Models.ActivityModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ActivityComments")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ActivityDurationMinutes")
                        .HasColumnType("int");

                    b.Property<DateTime>("ActivityStarted")
                        .HasColumnType("datetime2");

                    b.Property<string>("ActivityType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ActivityModel");
                });
#pragma warning restore 612, 618
        }
    }
}
