﻿// <auto-generated />
using System;
using HW_4_5.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HW_4_5.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230910072214_InitCreateDatabase")]
    partial class InitCreateDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HW_4_5.Models.Breed", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("BreedName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Breeds");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BreedName = "Dog Breed 1",
                            CategoryId = 1
                        },
                        new
                        {
                            Id = 2,
                            BreedName = "Cat Breed 1",
                            CategoryId = 2
                        },
                        new
                        {
                            Id = 3,
                            BreedName = "Parrot Breed 1",
                            CategoryId = 3
                        },
                        new
                        {
                            Id = 4,
                            BreedName = "Rodent Breed 1",
                            CategoryId = 4
                        });
                });

            modelBuilder.Entity("HW_4_5.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryName = "Dogs"
                        },
                        new
                        {
                            Id = 2,
                            CategoryName = "Cats"
                        },
                        new
                        {
                            Id = 3,
                            CategoryName = "Parrots"
                        },
                        new
                        {
                            Id = 4,
                            CategoryName = "Rodents"
                        });
                });

            modelBuilder.Entity("HW_4_5.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("LocationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Locations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LocationName = "Ukraine"
                        },
                        new
                        {
                            Id = 2,
                            LocationName = "Poland"
                        },
                        new
                        {
                            Id = 3,
                            LocationName = "Germany"
                        },
                        new
                        {
                            Id = 4,
                            LocationName = "Italy"
                        });
                });

            modelBuilder.Entity("HW_4_5.Models.Pet", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<float>("Age")
                        .HasColumnType("real");

                    b.Property<int?>("BreedId")
                        .HasColumnType("int");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BreedId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("LocationId");

                    b.ToTable("Pets");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 4f,
                            BreedId = 1,
                            CategoryId = 1,
                            Description = "Some description about dog 1.",
                            ImageUrl = "https://cdn.pixabay.com/photo/2021/04/21/21/03/dog-6197571_960_720.jpg",
                            LocationId = 1,
                            Name = "Dog 1"
                        },
                        new
                        {
                            Id = 2,
                            Age = 3f,
                            BreedId = 2,
                            CategoryId = 2,
                            Description = "Some description about cat 1.",
                            ImageUrl = "https://www.alleycat.org/wp-content/uploads/2019/03/FELV-cat.jpg",
                            LocationId = 2,
                            Name = "Cat 1"
                        },
                        new
                        {
                            Id = 3,
                            Age = 2f,
                            BreedId = 3,
                            CategoryId = 3,
                            Description = "Some description about parrot 1.",
                            ImageUrl = "https://i.natgeofe.com/n/e3ae5fbf-ddc9-4b18-8c75-81d2daf962c1/3948225.jpg",
                            LocationId = 3,
                            Name = "Parrot 1"
                        },
                        new
                        {
                            Id = 4,
                            Age = 1f,
                            BreedId = 4,
                            CategoryId = 4,
                            Description = "Some description about rodent 1.",
                            ImageUrl = "https://www.bluecross.org.uk/sites/default/files/d8/assets/images/114895lpr.jpg",
                            LocationId = 4,
                            Name = "Rodent 1"
                        });
                });

            modelBuilder.Entity("HW_4_5.Models.Breed", b =>
                {
                    b.HasOne("HW_4_5.Models.Category", "Category")
                        .WithMany("Breeds")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Category");
                });

            modelBuilder.Entity("HW_4_5.Models.Pet", b =>
                {
                    b.HasOne("HW_4_5.Models.Breed", "Breed")
                        .WithMany("Pets")
                        .HasForeignKey("BreedId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("HW_4_5.Models.Category", "Category")
                        .WithMany("Pets")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("HW_4_5.Models.Location", "Location")
                        .WithMany("Pets")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Breed");

                    b.Navigation("Category");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("HW_4_5.Models.Breed", b =>
                {
                    b.Navigation("Pets");
                });

            modelBuilder.Entity("HW_4_5.Models.Category", b =>
                {
                    b.Navigation("Breeds");

                    b.Navigation("Pets");
                });

            modelBuilder.Entity("HW_4_5.Models.Location", b =>
                {
                    b.Navigation("Pets");
                });
#pragma warning restore 612, 618
        }
    }
}
