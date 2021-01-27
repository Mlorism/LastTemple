﻿// <auto-generated />
using System;
using LastTemple.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LastTemple.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210126162007_names changed")]
    partial class nameschanged
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LastTemple.Creature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActionPoints")
                        .HasColumnType("int");

                    b.Property<int>("Agility")
                        .HasColumnType("int");

                    b.Property<bool>("Alive")
                        .HasColumnType("bit");

                    b.Property<int?>("ArmorId")
                        .HasColumnType("int");

                    b.Property<int>("BaseDamage")
                        .HasColumnType("int");

                    b.Property<int>("DamageResistance")
                        .HasColumnType("int");

                    b.Property<int>("Endurance")
                        .HasColumnType("int");

                    b.Property<int>("Experience")
                        .HasColumnType("int");

                    b.Property<int>("HitPoints")
                        .HasColumnType("int");

                    b.Property<int>("Initiative")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<int>("MagicResistance")
                        .HasColumnType("int");

                    b.Property<int>("Mana")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Speed")
                        .HasColumnType("int");

                    b.Property<int>("Strength")
                        .HasColumnType("int");

                    b.Property<int>("Supplies")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<int?>("WeaponId")
                        .HasColumnType("int");

                    b.Property<int>("Willpower")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArmorId");

                    b.HasIndex("WeaponId");

                    b.ToTable("Creatures");
                });

            modelBuilder.Entity("LastTemple.Models.Armor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DamageResistance")
                        .HasColumnType("int");

                    b.Property<int>("MagicResistance")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Armors");
                });

            modelBuilder.Entity("LastTemple.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CreatureId")
                        .HasColumnType("int");

                    b.Property<int>("ItemType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Strength")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatureId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("LastTemple.Models.Spell", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CreatureId")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<int>("ManaCost")
                        .HasColumnType("int");

                    b.Property<int>("Strength")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatureId");

                    b.ToTable("Spells");
                });

            modelBuilder.Entity("LastTemple.Models.Weapon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BaseActionCost")
                        .HasColumnType("int");

                    b.Property<int>("BaseDamage")
                        .HasColumnType("int");

                    b.Property<int>("BaseHitChance")
                        .HasColumnType("int");

                    b.Property<int>("Name")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Weapons");
                });

            modelBuilder.Entity("LastTemple.Creature", b =>
                {
                    b.HasOne("LastTemple.Models.Armor", "Armor")
                        .WithMany()
                        .HasForeignKey("ArmorId");

                    b.HasOne("LastTemple.Models.Weapon", "Weapon")
                        .WithMany()
                        .HasForeignKey("WeaponId");
                });

            modelBuilder.Entity("LastTemple.Models.Item", b =>
                {
                    b.HasOne("LastTemple.Creature", null)
                        .WithMany("Items")
                        .HasForeignKey("CreatureId");
                });

            modelBuilder.Entity("LastTemple.Models.Spell", b =>
                {
                    b.HasOne("LastTemple.Creature", null)
                        .WithMany("MagicBook")
                        .HasForeignKey("CreatureId");
                });
#pragma warning restore 612, 618
        }
    }
}
