﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StrikkebutikkBackend;

#nullable disable

namespace StrikkebutikkBackend.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20250130181122_v5")]
    partial class v5
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StrikkebutikkBackend.Model.Assortment", b =>
                {
                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.PrimitiveCollection<string>("colorIds")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("yarnId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Assortments");
                });

            modelBuilder.Entity("StrikkebutikkBackend.Model.Pattern", b =>
                {
                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<string>("img")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Patterns");
                });

            modelBuilder.Entity("StrikkebutikkBackend.Model.ProductWithForeignKey", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("assortmentId")
                        .HasColumnType("int");

                    b.Property<string>("category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("patternId")
                        .HasColumnType("int");

                    b.Property<int>("price")
                        .HasColumnType("int");

                    b.Property<string>("productAlbumJSON")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("productImg")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("productInfo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("productName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.Property<string>("sizesJSON")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("patternId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("StrikkebutikkBackend.Model.ProductWithForeignKey", b =>
                {
                    b.HasOne("StrikkebutikkBackend.Model.Pattern", "pattern")
                        .WithMany()
                        .HasForeignKey("patternId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("pattern");
                });
#pragma warning restore 612, 618
        }
    }
}
