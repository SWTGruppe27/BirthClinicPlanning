using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BirthClinicPlanning.Models;
using Microsoft.EntityFrameworkCore;

namespace BirthClinicPlanning.Data
{
    public class BirthClinicPlanningContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder ob)
        {
            ob.UseSqlServer(
                @"Data Source=(localdb)\DAB;Initial Catalog=BirthClinicPlanning;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Birth>().HasKey(b => b.BirthId);
            mb.Entity<Birth>().HasMany(b => b.ChildList)
                .WithOne(c => c.Birth)
                .HasForeignKey(c => c.BirthId);

            mb.Entity<Birth>().HasOne(b => b.BirthRoom)
                .WithOne(br => br.Birth)
                .HasForeignKey<BirthRoom>();

            mb.Entity<Child>().HasKey(c => c.CprNumber);
            mb.Entity<Child>().HasMany(c => c.RelativesChild)
                .WithOne(r => r.Child)
                .HasForeignKey(r => r.RelativesId);

            mb.Entity<Relatives>().HasKey(r => r.RelativesId);
            mb.Entity<Relatives>().HasMany(r => r.RelativesChildList)
                .WithOne(rc => rc.Relatives)
                .HasForeignKey(rc => rc.RelativesId);

            mb.Entity<RelativesChild>().HasKey(rc => rc.RelativesChildId);

            mb.Entity<Secretaries>().HasKey(s => s.EmployeeId);

            //mb.Entity<Relatives>().HasDiscriminator(r => r.Relation);
            //mb.Entity<Relatives>().p

            mb.Entity<RestRoom>().HasKey(rr => rr.RoomNumber);
            mb.Entity<RestRoom>().HasOne(rr => rr.Relatives)
                .WithOne(r => r.RestRoom)
                .HasForeignKey<RestRoom>();

            mb.Entity<BirthRoom>().HasKey(b => b.RoomNumber);
            mb.Entity<BirthRoom>().HasMany(b => b.CliniciansList)
                .WithOne(c => c.BirthRoom)
                .HasForeignKey(c => c.BirthRoomId);

            mb.Entity<Clinicians>().HasKey(c => c.EmployeeId);
            mb.Entity<Clinicians>().HasOne(c => c.BirthRoom)
                .WithMany(b => b.CliniciansList)
                .HasForeignKey(b => b.EmployeeId);
        }

        public DbSet<Secretaries> Secretaries { get; set; }
        public DbSet<Clinicians> Clinicians { get; set; }
        public DbSet<Midwifes> Midwifes { get; set; }
        public DbSet<Doctors> Doctors { get; set; }
        public DbSet<Sosu> Sosus { get; set; }
        public DbSet<Nurses> Nurses { get; set; }
        public DbSet<Relatives> Relatives { get; set; }
        public DbSet<Birth> Births { get; set; }
        public DbSet<Child> Children { get; set; }
        public DbSet<RestRoom> RestRooms { get; set; }
        public DbSet<RestRoom4Hours> RestRoom4Hours { get; set; }
        public DbSet<MaternityRoom> MaternityRooms { get; set; }
        public DbSet<BirthRoom> BirthRooms { get; set; }
    }
}
