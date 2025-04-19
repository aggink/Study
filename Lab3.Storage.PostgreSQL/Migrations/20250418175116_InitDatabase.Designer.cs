﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Study.Lab3.Storage.Database;

#nullable disable

namespace Lab3.Storage.PostgreSQL.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20250418175116_InitDatabase")]
    partial class InitDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Lab3.Storage.Models.Students.Group", b =>
                {
                    b.Property<Guid>("IsnGroup")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.HasKey("IsnGroup");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("Lab3.Storage.Models.Students.Student", b =>
                {
                    b.Property<Guid>("IsnStudent")
                        .HasColumnType("uuid");

                    b.Property<Guid>("IsnGroup")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("PatronymicName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("Sex")
                        .HasColumnType("integer");

                    b.Property<string>("SurName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("IsnStudent");

                    b.HasIndex("IsnGroup");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Lab3.Storage.Models.Students.Subject", b =>
                {
                    b.Property<Guid>("IsnSubject")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("IsnSubject");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("Lab3.Storage.Models.Students.SubjectGroup", b =>
                {
                    b.Property<Guid>("IsnSubject")
                        .HasColumnType("uuid");

                    b.Property<Guid>("IsnGroup")
                        .HasColumnType("uuid");

                    b.HasKey("IsnSubject", "IsnGroup");

                    b.HasIndex("IsnGroup");

                    b.HasIndex("IsnSubject", "IsnGroup");

                    b.ToTable("SubjectGroup");
                });

            modelBuilder.Entity("Lab3.Storage.Models.Students.Student", b =>
                {
                    b.HasOne("Lab3.Storage.Models.Students.Group", "Group")
                        .WithMany("Students")
                        .HasForeignKey("IsnGroup")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");
                });

            modelBuilder.Entity("Lab3.Storage.Models.Students.SubjectGroup", b =>
                {
                    b.HasOne("Lab3.Storage.Models.Students.Subject", "Subject")
                        .WithMany("GroupSubjects")
                        .HasForeignKey("IsnGroup")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lab3.Storage.Models.Students.Group", "Group")
                        .WithMany("SubjectGroups")
                        .HasForeignKey("IsnSubject")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("Lab3.Storage.Models.Students.Group", b =>
                {
                    b.Navigation("Students");

                    b.Navigation("SubjectGroups");
                });

            modelBuilder.Entity("Lab3.Storage.Models.Students.Subject", b =>
                {
                    b.Navigation("GroupSubjects");
                });
#pragma warning restore 612, 618
        }
    }
}
