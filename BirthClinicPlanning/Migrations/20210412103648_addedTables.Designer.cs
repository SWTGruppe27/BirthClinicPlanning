﻿// <auto-generated />
using BirthClinicPlanning.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BirthClinicPlanning.Migrations
{
    [DbContext(typeof(BirthClinicPlanningContext))]
    [Migration("20210412103648_addedTables")]
    partial class addedTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BirthClinicPlanning.Birth", b =>
                {
                    b.Property<int>("BirthId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("BirthId");

                    b.ToTable("Births");
                });

            modelBuilder.Entity("BirthClinicPlanning.Child", b =>
                {
                    b.Property<int>("CprNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BirthId")
                        .HasColumnType("int");

                    b.HasKey("CprNumber");

                    b.HasIndex("BirthId");

                    b.ToTable("Children");
                });

            modelBuilder.Entity("BirthClinicPlanning.Clinicians", b =>
                {
                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("BirthRoomId")
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.ToTable("Clinicians");
                });

            modelBuilder.Entity("BirthClinicPlanning.Models.BirthRoom", b =>
                {
                    b.Property<int>("RoomNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BirthId")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("RoomType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoomNumber");

                    b.HasIndex("BirthId")
                        .IsUnique();

                    b.ToTable("BirthRooms");
                });

            modelBuilder.Entity("BirthClinicPlanning.Models.Relatives", b =>
                {
                    b.Property<int>("RelativesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Relation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RestRoomId")
                        .HasColumnType("int");

                    b.HasKey("RelativesId");

                    b.ToTable("Relatives");
                });

            modelBuilder.Entity("BirthClinicPlanning.Models.RelativesChild", b =>
                {
                    b.Property<int>("RelativesChildId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CprNumber")
                        .HasColumnType("int");

                    b.Property<int>("RelativesId")
                        .HasColumnType("int");

                    b.HasKey("RelativesChildId");

                    b.HasIndex("RelativesId");

                    b.ToTable("RelativesChild");
                });

            modelBuilder.Entity("BirthClinicPlanning.Models.RestRoom", b =>
                {
                    b.Property<int>("RoomNumber")
                        .HasColumnType("int");

                    b.Property<string>("RoomType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoomNumber");

                    b.ToTable("RestRooms");
                });

            modelBuilder.Entity("BirthClinicPlanning.Models.Secretaries", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.ToTable("Secretaries");
                });

            modelBuilder.Entity("BirthClinicPlanning.Doctors", b =>
                {
                    b.HasBaseType("BirthClinicPlanning.Clinicians");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("BirthClinicPlanning.Midwifes", b =>
                {
                    b.HasBaseType("BirthClinicPlanning.Clinicians");

                    b.ToTable("Midwifes");
                });

            modelBuilder.Entity("BirthClinicPlanning.Nurses", b =>
                {
                    b.HasBaseType("BirthClinicPlanning.Clinicians");

                    b.ToTable("Nurses");
                });

            modelBuilder.Entity("BirthClinicPlanning.Sosu", b =>
                {
                    b.HasBaseType("BirthClinicPlanning.Clinicians");

                    b.ToTable("Sosu");
                });

            modelBuilder.Entity("BirthClinicPlanning.Models.Family", b =>
                {
                    b.HasBaseType("BirthClinicPlanning.Models.Relatives");

                    b.ToTable("Families");
                });

            modelBuilder.Entity("BirthClinicPlanning.Models.Father", b =>
                {
                    b.HasBaseType("BirthClinicPlanning.Models.Relatives");

                    b.Property<string>("CPRNumber")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Fathers");
                });

            modelBuilder.Entity("BirthClinicPlanning.Models.Mother", b =>
                {
                    b.HasBaseType("BirthClinicPlanning.Models.Relatives");

                    b.Property<string>("CPRNumber")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Mothers");
                });

            modelBuilder.Entity("BirthClinicPlanning.MaternityRoom", b =>
                {
                    b.HasBaseType("BirthClinicPlanning.Models.RestRoom");

                    b.ToTable("MaternityRooms");
                });

            modelBuilder.Entity("BirthClinicPlanning.RestRoom4Hours", b =>
                {
                    b.HasBaseType("BirthClinicPlanning.Models.RestRoom");

                    b.ToTable("RestRoom4Hours");
                });

            modelBuilder.Entity("BirthClinicPlanning.Child", b =>
                {
                    b.HasOne("BirthClinicPlanning.Birth", "Birth")
                        .WithMany("ChildList")
                        .HasForeignKey("BirthId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Birth");
                });

            modelBuilder.Entity("BirthClinicPlanning.Clinicians", b =>
                {
                    b.HasOne("BirthClinicPlanning.Models.BirthRoom", "BirthRoom")
                        .WithMany("CliniciansList")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BirthRoom");
                });

            modelBuilder.Entity("BirthClinicPlanning.Models.BirthRoom", b =>
                {
                    b.HasOne("BirthClinicPlanning.Birth", "Birth")
                        .WithOne("BirthRoom")
                        .HasForeignKey("BirthClinicPlanning.Models.BirthRoom", "BirthId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Birth");
                });

            modelBuilder.Entity("BirthClinicPlanning.Models.RelativesChild", b =>
                {
                    b.HasOne("BirthClinicPlanning.Child", "Child")
                        .WithMany("RelativesChild")
                        .HasForeignKey("RelativesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BirthClinicPlanning.Models.Relatives", "Relatives")
                        .WithMany("RelativesChildList")
                        .HasForeignKey("RelativesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Child");

                    b.Navigation("Relatives");
                });

            modelBuilder.Entity("BirthClinicPlanning.Models.RestRoom", b =>
                {
                    b.HasOne("BirthClinicPlanning.Models.Relatives", "Relatives")
                        .WithOne("RestRoom")
                        .HasForeignKey("BirthClinicPlanning.Models.RestRoom", "RoomNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Relatives");
                });

            modelBuilder.Entity("BirthClinicPlanning.Doctors", b =>
                {
                    b.HasOne("BirthClinicPlanning.Clinicians", null)
                        .WithOne()
                        .HasForeignKey("BirthClinicPlanning.Doctors", "EmployeeId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BirthClinicPlanning.Midwifes", b =>
                {
                    b.HasOne("BirthClinicPlanning.Clinicians", null)
                        .WithOne()
                        .HasForeignKey("BirthClinicPlanning.Midwifes", "EmployeeId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BirthClinicPlanning.Nurses", b =>
                {
                    b.HasOne("BirthClinicPlanning.Clinicians", null)
                        .WithOne()
                        .HasForeignKey("BirthClinicPlanning.Nurses", "EmployeeId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BirthClinicPlanning.Sosu", b =>
                {
                    b.HasOne("BirthClinicPlanning.Clinicians", null)
                        .WithOne()
                        .HasForeignKey("BirthClinicPlanning.Sosu", "EmployeeId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BirthClinicPlanning.Models.Family", b =>
                {
                    b.HasOne("BirthClinicPlanning.Models.Relatives", null)
                        .WithOne()
                        .HasForeignKey("BirthClinicPlanning.Models.Family", "RelativesId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BirthClinicPlanning.Models.Father", b =>
                {
                    b.HasOne("BirthClinicPlanning.Models.Relatives", null)
                        .WithOne()
                        .HasForeignKey("BirthClinicPlanning.Models.Father", "RelativesId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BirthClinicPlanning.Models.Mother", b =>
                {
                    b.HasOne("BirthClinicPlanning.Models.Relatives", null)
                        .WithOne()
                        .HasForeignKey("BirthClinicPlanning.Models.Mother", "RelativesId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BirthClinicPlanning.MaternityRoom", b =>
                {
                    b.HasOne("BirthClinicPlanning.Models.RestRoom", null)
                        .WithOne()
                        .HasForeignKey("BirthClinicPlanning.MaternityRoom", "RoomNumber")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BirthClinicPlanning.RestRoom4Hours", b =>
                {
                    b.HasOne("BirthClinicPlanning.Models.RestRoom", null)
                        .WithOne()
                        .HasForeignKey("BirthClinicPlanning.RestRoom4Hours", "RoomNumber")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BirthClinicPlanning.Birth", b =>
                {
                    b.Navigation("BirthRoom");

                    b.Navigation("ChildList");
                });

            modelBuilder.Entity("BirthClinicPlanning.Child", b =>
                {
                    b.Navigation("RelativesChild");
                });

            modelBuilder.Entity("BirthClinicPlanning.Models.BirthRoom", b =>
                {
                    b.Navigation("CliniciansList");
                });

            modelBuilder.Entity("BirthClinicPlanning.Models.Relatives", b =>
                {
                    b.Navigation("RelativesChildList");

                    b.Navigation("RestRoom");
                });
#pragma warning restore 612, 618
        }
    }
}
