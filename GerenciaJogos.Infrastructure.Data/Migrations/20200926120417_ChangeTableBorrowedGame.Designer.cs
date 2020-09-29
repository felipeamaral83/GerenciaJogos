﻿// <auto-generated />
using System;
using GerenciaJogos.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GerenciaJogos.Infrastructure.Data.Migrations
{
    [DbContext(typeof(GerenciaJogosModel))]
    [Migration("20200926120417_ChangeTableBorrowedGame")]
    partial class ChangeTableBorrowedGame
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GerenciaJogos.Domain.Entities.BorrowedGame", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdFriend")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdGame")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdUser")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("LoanDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("IdFriend");

                    b.HasIndex("IdGame");

                    b.HasIndex("IdUser");

                    b.ToTable("BorrowedGame");
                });

            modelBuilder.Entity("GerenciaJogos.Domain.Entities.Friend", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdUser")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Nickname")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Whatsapp")
                        .HasColumnType("nvarchar(11)")
                        .HasMaxLength(11);

                    b.HasKey("Id");

                    b.HasIndex("IdUser");

                    b.ToTable("Friend");
                });

            modelBuilder.Entity("GerenciaJogos.Domain.Entities.Game", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Borrowed")
                        .HasColumnType("bit");

                    b.Property<Guid>("IdUser")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("IdUser");

                    b.ToTable("Game");
                });

            modelBuilder.Entity("GerenciaJogos.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("GerenciaJogos.Domain.Entities.BorrowedGame", b =>
                {
                    b.HasOne("GerenciaJogos.Domain.Entities.Friend", "Friend")
                        .WithMany("BorrowedGames")
                        .HasForeignKey("IdFriend")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("GerenciaJogos.Domain.Entities.Game", "Game")
                        .WithMany("BorrowedGames")
                        .HasForeignKey("IdGame")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("GerenciaJogos.Domain.Entities.User", "User")
                        .WithMany("BorrowedGames")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("GerenciaJogos.Domain.Entities.Friend", b =>
                {
                    b.HasOne("GerenciaJogos.Domain.Entities.User", "User")
                        .WithMany("Friends")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("GerenciaJogos.Domain.Entities.Game", b =>
                {
                    b.HasOne("GerenciaJogos.Domain.Entities.User", "User")
                        .WithMany("Games")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
