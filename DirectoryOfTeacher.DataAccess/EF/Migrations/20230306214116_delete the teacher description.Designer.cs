﻿// <auto-generated />
using System;
using DirectoryOfTeacher.DataAccess.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DirectoryOfTeacher.DataAccess.EF.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230306214116_delete the teacher description")]
    partial class deletetheteacherdescription
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DirectoryOfTeachers.Core.Models.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("EducationalInstitution")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("DirectoryOfTeachers.Core.Models.TeacherCharacteristic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("TeacherCharacteristics");
                });

            modelBuilder.Entity("DirectoryOfTeachers.Core.Models.TeacherCharacteristicDislike", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("TeacherCharacteristicId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeacherCharacteristicId");

                    b.ToTable("TeacherCharacteristicDislikes");
                });

            modelBuilder.Entity("DirectoryOfTeachers.Core.Models.TeacherCharacteristicLike", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("TeacherCharacteristicId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeacherCharacteristicId");

                    b.ToTable("TeacherCharacteristicLikes");
                });

            modelBuilder.Entity("DirectoryOfTeachers.Core.Models.TeacherCharacteristic", b =>
                {
                    b.HasOne("DirectoryOfTeachers.Core.Models.Teacher", null)
                        .WithMany("Characteristics")
                        .HasForeignKey("TeacherId");
                });

            modelBuilder.Entity("DirectoryOfTeachers.Core.Models.TeacherCharacteristicDislike", b =>
                {
                    b.HasOne("DirectoryOfTeachers.Core.Models.TeacherCharacteristic", null)
                        .WithMany("Dislikes")
                        .HasForeignKey("TeacherCharacteristicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DirectoryOfTeachers.Core.Models.TeacherCharacteristicLike", b =>
                {
                    b.HasOne("DirectoryOfTeachers.Core.Models.TeacherCharacteristic", null)
                        .WithMany("Likes")
                        .HasForeignKey("TeacherCharacteristicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DirectoryOfTeachers.Core.Models.Teacher", b =>
                {
                    b.Navigation("Characteristics");
                });

            modelBuilder.Entity("DirectoryOfTeachers.Core.Models.TeacherCharacteristic", b =>
                {
                    b.Navigation("Dislikes");

                    b.Navigation("Likes");
                });
#pragma warning restore 612, 618
        }
    }
}
