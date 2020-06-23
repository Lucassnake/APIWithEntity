﻿// <auto-generated />
using System;
using APIWithEntity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace APIWithEntity.Migrations
{
    [DbContext(typeof(HeroContext))]
    [Migration("20200608233502_BattlesIdentity")]
    partial class BattlesIdentity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("APIWithEntity.Models.Battle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<DateTime>("DtEnde");

                    b.Property<DateTime>("DtStart");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Battles");
                });

            modelBuilder.Entity("APIWithEntity.Models.BattleHero", b =>
                {
                    b.Property<int>("BattleId");

                    b.Property<int>("HeroId");

                    b.HasKey("BattleId", "HeroId");

                    b.HasIndex("HeroId");

                    b.ToTable("BattleHeroes");
                });

            modelBuilder.Entity("APIWithEntity.Models.Hero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Heros");
                });

            modelBuilder.Entity("APIWithEntity.Models.SecretIdentity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HeroId");

                    b.Property<string>("RealName");

                    b.HasKey("Id");

                    b.HasIndex("HeroId")
                        .IsUnique();

                    b.ToTable("SecretIdentities");
                });

            modelBuilder.Entity("APIWithEntity.Models.Weapon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HeroId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("HeroId");

                    b.ToTable("Weapons");
                });

            modelBuilder.Entity("APIWithEntity.Models.BattleHero", b =>
                {
                    b.HasOne("APIWithEntity.Models.Battle", "Battle")
                        .WithMany("BattlesHeros")
                        .HasForeignKey("BattleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("APIWithEntity.Models.Hero", "Hero")
                        .WithMany("BattlesHeros")
                        .HasForeignKey("HeroId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("APIWithEntity.Models.SecretIdentity", b =>
                {
                    b.HasOne("APIWithEntity.Models.Hero", "Hero")
                        .WithOne("SecretIdentity")
                        .HasForeignKey("APIWithEntity.Models.SecretIdentity", "HeroId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("APIWithEntity.Models.Weapon", b =>
                {
                    b.HasOne("APIWithEntity.Models.Hero", "Hero")
                        .WithMany("Weapons")
                        .HasForeignKey("HeroId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
