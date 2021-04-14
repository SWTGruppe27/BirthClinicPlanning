using System.Collections.Generic;
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

            mb.Entity<Reservation>().HasKey(r => r.ReservationId);
            mb.Entity<Works>().HasKey(w => w.WorksId);

            mb.Entity<Clinicians>().HasKey(c => c.EmployeeId);
            mb.Entity<Clinicians>().HasMany(c => c.WorksList)
                .WithOne(w => w.Clinicians)
                .HasForeignKey(w => w.EmployeeId);

            mb.Entity<Birth>().HasMany(b => b.WorksList)
                .WithOne(w => w.Birth)
                .HasForeignKey(w => w.BirthId);

            mb.Entity<Room>().HasKey(r => r.RoomNumber);
            mb.Entity<Room>().HasMany(r => r.ReservationList)
                .WithOne(r =>r.Room)
                .HasForeignKey(r => r.RoomId);

            mb.Entity<Child>().HasKey(c => c.ChildId);
            mb.Entity<Child>().HasMany(c => c.RelativesChild)
                .WithOne(r => r.Child)
                .HasForeignKey(r => r.RelativesId);

            mb.Entity<Relatives>().HasKey(r => r.RelativesId);
            mb.Entity<Relatives>().HasMany(r => r.RelativesChildList)
                .WithOne(rc => rc.Relatives)
                .HasForeignKey(rc => rc.RelativesId);

            mb.Entity<Relatives>().HasMany(r => r.ReservationList)
                .WithOne(r => r.Relatives)
                .HasForeignKey(r => r.RelativesId);

            mb.Entity<Father>().ToTable("Fathers");
            mb.Entity<Mother>().ToTable("Mothers");
            mb.Entity<Family>().ToTable("Families");

            mb.Entity<RelativesChild>().HasKey(rc => rc.RelativesChildId);

            mb.Entity<Secretaries>().HasKey(s => s.EmployeeId);
            mb.Entity<Secretaries>().ToTable("Secretaries");

            mb.Entity<MaternityRoom>().ToTable("MaternityRooms");
            mb.Entity<BirthRoom>().ToTable("BirthRooms");
            mb.Entity<RestRoom>().ToTable("RestRooms");
            mb.Entity<RestRoom4Hours>().ToTable("RestRoom4Hours");

            mb.Entity<Doctors>().ToTable("Doctors");
            mb.Entity<Midwifes>().ToTable("Midwifes");
            mb.Entity<Nurses>().ToTable("Nurses");
            mb.Entity<Sosu>().ToTable("Sosu");


            SeedData(mb);
        }
        private void SeedData(ModelBuilder mb)
        {
            int numberOfSous = 20;

            string[] namesSosus = new string[] {"Sofie Jensen", "Søren Larsen", "Sarah Hansen", "Susanne Himmelblå", "Simon Bjermand Kjær", "Simon Schou Jensen", "Selma Jakobsen", "Susan Kristensen", "Stine Olsen", "Sandra Toft", "Silke Rasmusen", "Siff Andersen", "Sophie Loft", "Sol-Solvej Solskin", "Simone Kjær", "Sabrina Møller Andersen", "Sara Christensen", "Sascha Madsen", "Sidsel Lund Sørensen", "Sten Steensen"};
            
            List<Sosu> sosus = new List<Sosu>();
           
            for (int i = 1; i < numberOfSous+1; i++)
            {
                Sosu s = new Sosu(namesSosus[i - 1]);
                s.EmployeeId = i;
                sosus.Add(s);
            }

            mb.Entity<Sosu>().HasData(sosus);


            int numberOfDoctors = 5;

            string[] namesDoctor = new string[5] { "Danny Boy", "Dirk Passer", "David Davidson", "Diana Jensen", "Daniel Danielsen"};

            List<Doctors> doctors = new List<Doctors>();

            for (int i = numberOfSous+1; i < numberOfSous+numberOfDoctors + 1; i++)
            {
                Doctors d = new Doctors(namesDoctor[i - numberOfSous-1]);
                d.EmployeeId = i;
                doctors.Add(d);
            }

            mb.Entity<Sosu>().HasData(doctors);


            int numberOfNurses = 20;

            string[] namesNurses = new string[20] { "Niels Nielsen", "Nikolaj Nikolajsen", "Niklas Landin", "Natasha Romanoff", "Natalia Alianovna Romanova", "Nicki Sørensen", "Niller Nielsen", "Noah Overbyen", "Nik Petersen", "Nora Andersen", "Nadai Jensen", "Nikita Mortensen Bækgaard", "Nanna Louise Johansen", "Nelly Winston", "Naja Madsen", "Neville Longbottom", "Norbit Albertrise", "No Name", "Nairobi Kenya", "Norge Nordmand" };

            List<Nurses> nurses = new List<Nurses>();

            for (int i = numberOfSous+ numberOfDoctors+1; i < numberOfSous + numberOfDoctors + numberOfNurses + 1; i++)
            {
                Nurses n = new Nurses(namesNurses[i - numberOfSous - numberOfDoctors- 1]);
                n.EmployeeId = i;
                nurses.Add(n);
            }

            mb.Entity<Nurses>().HasData(nurses);


            int numberOfMidwifes = 10;

            string[] namesMidwifes = new string[10] { "Malfoy Draco", "Mille Madsen", "Mads Madsen", "Marie Toft", "Malene Sørensen", "Morten Mortensen", "Martin Frederiksen", "Marcus Nielsen", "Maja Mikkelsen", "Maria Loft Nielsen"};

            List<Midwifes> midwifes = new List<Midwifes>();

            for (int i = numberOfSous + numberOfDoctors + numberOfNurses+1; i < numberOfSous + numberOfDoctors + numberOfNurses + numberOfMidwifes + 1; i++)
            {
                Midwifes m = new Midwifes(namesMidwifes[i - numberOfSous - numberOfDoctors - numberOfNurses - 1]);
                m.EmployeeId = i;
                midwifes.Add(m);
            }

            mb.Entity<Midwifes>().HasData(midwifes);


            int numberOfSecretaries = 4;

            string[] namesSecretaries = new string[4] { "Simba Kongesøn", "Signe Mikkelsen", "Sune Orlater", "Søren Krag"};

            List<Secretaries> secretaries = new List<Secretaries>();

            for (int i = numberOfSous + numberOfDoctors + numberOfNurses + numberOfMidwifes +1 ; i < numberOfSous + numberOfDoctors + numberOfNurses + numberOfMidwifes + numberOfSecretaries + 1; i++)
            {
                Secretaries ss = new Secretaries(namesSecretaries[i - numberOfSous - numberOfDoctors - numberOfNurses - numberOfMidwifes - 1]);
                ss.EmployeeId = i;
                secretaries.Add(ss);
            }

            mb.Entity<Secretaries>().HasData(secretaries);

            List<MaternityRoom> maternityRooms = new List<MaternityRoom>();

            for (int i = 1; i < 23; i++)
            {
                MaternityRoom maternityRoom = new MaternityRoom();
                maternityRoom.RoomNumber = i;
                maternityRooms.Add(maternityRoom);
            }
            mb.Entity<MaternityRoom>().HasData(maternityRooms);

            List<RestRoom4Hours> restRoom4Hours = new List<RestRoom4Hours>();

            for (int i = 23; i < 28; i++)
            {
                RestRoom4Hours restRoom4Hour = new RestRoom4Hours();
                restRoom4Hour.RoomNumber = i;
                restRoom4Hours.Add(restRoom4Hour);
            }
            mb.Entity<MaternityRoom>().HasData(restRoom4Hours);

            List<BirthRoom> birthRooms = new List<BirthRoom>();

            for (int i = 28; i < 43; i++)
            {
                BirthRoom birthRoom = new BirthRoom();
                birthRoom.RoomNumber = i;
                birthRooms.Add(birthRoom);
            }
            mb.Entity<BirthRoom>().HasData(birthRooms);

            List<Reservation> reservations = new List<Reservation>();

            for (int i = 1; i < 43 ; i++)
            {
                Reservation reservation = new Reservation();
                reservation.ReservationId = i;
                reservation.RoomId = i;
                reservations.Add(reservation);
            }

            mb.Entity<Reservation>().HasData(reservations);
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
        public DbSet<Father> Fathers { get; set; }
        public DbSet<Mother> Mothers { get; set; }
        public DbSet<Family> Families { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Works> Works { get; set; }

    }
}
