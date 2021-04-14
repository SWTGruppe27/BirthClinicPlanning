using System;
using System.Linq;
using BirthClinicPlanning.Data;
using Microsoft.EntityFrameworkCore;

namespace BirthClinicPlanning
{
    public class DatabaseSearch
    {
        private BirthClinicPlanningContext _context;

        public DatabaseSearch(BirthClinicPlanningContext context)
        {
            _context = context;
        }

        public void ShowPlannedBirths()
        {
            var birthList = _context.Births.Where(b => (b.PlannedStartDate.Date == DateTime.Now.Date
                                                       || b.PlannedStartDate.Date == DateTime.Now.Date.AddDays(1)
                                                       || b.PlannedStartDate.Date == DateTime.Now.Date.AddDays(2)) 
                                                       && b.PlannedEndDate !> DateTime.Now).ToList();
            foreach (var birth in birthList)
            {
                Console.WriteLine($"\nFødsels id: {birth.BirthId}");
                Console.WriteLine($"Planlagt start tid: { birth.PlannedStartDate}");
                Console.WriteLine($"Planlagt slut tid: {birth.PlannedEndDate}");
            }

            Console.WriteLine();
        }

        public void ShowAvaliableClinciansAndRoomsForNextFiveDays()
        {
            DateTime dateTime = new DateTime(1, 1, 1, 0, 0, 0, 0);

            var reservationList = _context.Reservations
                .Include(r => r.Room)
                .Where(r => r.ReservationStartDate >= DateTime.Now.AddDays(4) || r.ReservationStartDate == dateTime);

            foreach (var reservation in reservationList)
            {
                Console.WriteLine($"RumNummer: {reservation.Room.RoomNumber} " +
                                  $"\nType rum: {reservation.Room.RoomType} ");
            }

            Console.WriteLine();

            var cliniciansList = _context.Clinicians
                .Include(c => c.WorksList)
                .ThenInclude(w => w.Birth)
                .Where(c => c.BirthRoomId == 0);

            foreach (var clinician in cliniciansList)
            {
                Console.WriteLine($"Medarbejder id: {clinician.EmployeeId} \nTitel: {clinician.Position}");
            }

        }

        public void ShowInfoAboutOngoingBirths()
        {
            var birthList = _context.Births
                .Include(b => b.WorksList)
                .ThenInclude(w => w.Clinicians)
                .Include(b => b.ChildList)
                .ThenInclude(c => c.RelativesChild)
                .ThenInclude(cr => cr.Relatives)
                .ThenInclude(re => re.ReservationList)
                .ThenInclude(r => r.Room)
                .Where(b => b.PlannedEndDate > DateTime.Now.Date); // virker ikke med dato

            foreach (var birth in birthList)
            {
                Console.WriteLine($"Fødses id: {birth.BirthId}");

                Console.WriteLine("Klinikere tilknyttet:");

                foreach (var works in birth.WorksList)
                {
                    Console.WriteLine($"Medarbejder id: {works.Clinicians.EmployeeId} " +
                                      $"\nNavn: {works.Clinicians.FullName} " +
                                      $"\nTitle: {works.Clinicians.Title}");
                }

                foreach (var child in birth.ChildList)
                {
                    foreach (var relatives in child.RelativesChild)
                    {
                        switch (relatives.Relatives.Relation)
                        {
                            case "Mother":
                                Console.WriteLine($"Mor: {relatives.Relatives.FullName}");
                                break;
                            case "Father":
                                Console.WriteLine($"Far: {relatives.Relatives.FullName}");
                                break;
                        }

                        foreach (var reservation in relatives.Relatives.ReservationList)
                        {
                            Console.WriteLine($"Rum id: {reservation.RoomId}");
                        }
                    }
                }
            }
        }

        public void ShowInfoAboutRestRoomsInUse()
        {
            var reservationList = _context.Reservations
                .Include(r => r.Room)
                .Include(r => r.Relatives)
                .Where(r => r.ReservationEndDate > DateTime.Now && r.ReservationStartDate < DateTime.Now);

            foreach (var reservation in reservationList)
            {
                if (reservation.Room.RoomType != "BirthRoom")
                {
                    Console.WriteLine($"Rum Id: {reservation.RoomId} " +
                                      $"\nRum type: {reservation.Room.RoomType} " +
                                      $"\nStart dato: {reservation.ReservationStartDate}" +
                                      $"\nSlut dato: {reservation.ReservationEndDate}\n" +
                                      $"Navn på {reservation.Relatives.Relation}: {reservation.Relatives.FullName}");

                    if (reservation.Relatives.RelativesChildList != null)
                    {
                        foreach (var relativesChild in reservation.Relatives.RelativesChildList)
                        {
                            Console.WriteLine($"Barn Id: {relativesChild.Child.ChildId} " +
                                              $"\nCpr nummer: { relativesChild.Child.CprNumber}");
                        }
                    }
                }
                Console.WriteLine();
            }
        }

        public void ShowReservedRooms(int id)
        {
            var birthList = _context.Births
                .Include(b => b.WorksList)
                .ThenInclude(w => w.Clinicians)
                .Include(b => b.ChildList)
                .ThenInclude(c => c.RelativesChild)
                .ThenInclude(cr => cr.Relatives)
                .ThenInclude(re => re.ReservationList)
                .ThenInclude(r => r.Room)
                .Where(b => b.BirthId == id);

            foreach (var birth in birthList)
            {
                Console.WriteLine($"Fødses id: {birth.BirthId}");

                foreach (var child in birth.ChildList)
                {
                    foreach (var relatives in child.RelativesChild)
                    {
                        foreach (var reservation in relatives.Relatives.ReservationList)
                        {
                            Console.WriteLine($"Rum id: {reservation.RoomId} \nRum type: {reservation.Room.RoomType}");
                        }
                    }
                }
            }
            Console.WriteLine();
        }

        public void ShowCliniciansAssignedBirths(int birthId)
        {
            var birthList = _context.Births
                .Include(b => b.WorksList)
                .ThenInclude(w => w.Clinicians)
                .Where(b => b.BirthId == birthId);

            foreach (var birth in birthList)
            {
                Console.WriteLine($"Fødses id: {birth.BirthId}");

                Console.WriteLine("Klinikere tilknyttet:");

                foreach (var works in birth.WorksList)
                {
                    Console.WriteLine($"Medarbejder id: {works.Clinicians.EmployeeId} " +
                                      $"\nNavn: {works.Clinicians.FullName} " +
                                      $"\nPosition: {works.Clinicians.Position}");
                    
                }
            }

            Console.WriteLine();
        }
    }
}
