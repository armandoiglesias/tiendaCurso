﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TiendaService.Api.Author.Models.Persistance;

namespace TiendaService.Api.Author.Migrations
{
    [DbContext(typeof(ContextAuthor))]
    partial class ContextAuthorModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TiendaService.Api.Author.Models.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AuthorId").HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("BirthDate");

                    b.Property<string>("LastName");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Author");
                });

            modelBuilder.Entity("TiendaService.Api.Author.Models.EducationDegree", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AuthorId");

                    b.Property<Guid?>("AuthorLibroId");

                    b.Property<int>("EducationDegreeId").HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("GraduationDate");

                    b.Property<string>("Name");

                    b.Property<string>("SchoolName");

                    b.HasKey("Id");

                    b.HasIndex("AuthorLibroId");

                    b.ToTable("AuthorEducationDegree");
                });

            modelBuilder.Entity("TiendaService.Api.Author.Models.EducationDegree", b =>
                {
                    b.HasOne("TiendaService.Api.Author.Models.Author", "AuthorLibro")
                        .WithMany("ListEducationDegree")
                        .HasForeignKey("AuthorLibroId");
                });
#pragma warning restore 612, 618
        }
    }
}