﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TiendaService.WebApi.Cart.Models.Persistance;

namespace TiendaService.WebApi.Cart.Migrations
{
    [DbContext(typeof(CartContext))]
    partial class CartContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("TiendaService.WebApi.Cart.Models.CartDetail", b =>
                {
                    b.Property<int>("CartDetailId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CartSessionId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("ProductId");

                    b.HasKey("CartDetailId");

                    b.HasIndex("CartSessionId");

                    b.ToTable("CartDetail");
                });

            modelBuilder.Entity("TiendaService.WebApi.Cart.Models.CartSession", b =>
                {
                    b.Property<int>("CartSessionId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.HasKey("CartSessionId");

                    b.ToTable("CartSession");
                });

            modelBuilder.Entity("TiendaService.WebApi.Cart.Models.CartDetail", b =>
                {
                    b.HasOne("TiendaService.WebApi.Cart.Models.CartSession", "CartSession")
                        .WithMany("DetailList")
                        .HasForeignKey("CartSessionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}