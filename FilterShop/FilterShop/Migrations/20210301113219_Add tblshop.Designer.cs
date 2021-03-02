﻿// <auto-generated />
using FilterShop.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace FilterShop.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20210301113219_Add tblshop")]
    partial class Addtblshop
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("FilterShop.Entities.FilterName", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(250)")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.ToTable("tblFilterNames");
                });

            modelBuilder.Entity("FilterShop.Entities.FilterNameGroup", b =>
                {
                    b.Property<int>("FilterValueId")
                        .HasColumnType("integer");

                    b.Property<int>("FilterNameId")
                        .HasColumnType("integer");

                    b.HasKey("FilterValueId", "FilterNameId");

                    b.HasIndex("FilterNameId");

                    b.ToTable("tblFilterNameGroups");
                });

            modelBuilder.Entity("FilterShop.Entities.FilterValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(250)")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.ToTable("tblFilterValues");
                });

            modelBuilder.Entity("FilterShop.Entities.FilterNameGroup", b =>
                {
                    b.HasOne("FilterShop.Entities.FilterName", "FilterNameOf")
                        .WithMany("FilterNameGroups")
                        .HasForeignKey("FilterNameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FilterShop.Entities.FilterValue", "FilterValueOf")
                        .WithMany("FilterNameGroups")
                        .HasForeignKey("FilterValueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}