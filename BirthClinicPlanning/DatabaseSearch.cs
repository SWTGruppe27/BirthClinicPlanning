using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
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
            var birthList = _context.Births.Where(b => b.PlannedStartDate.Date == DateTime.Now.Date
                                                       || b.PlannedStartDate.Date == DateTime.Now.Date.AddDays(1)
                                                       || b.PlannedStartDate.Date == DateTime.Now.Date.AddDays(2)).ToList();
            foreach (var birth in birthList)
            {
                Console.WriteLine($"\nFødsels id: {birth.BirthId}");
                Console.WriteLine($"Planlagt start tid: { birth.PlannedStartDate}");
                Console.WriteLine($"Planlagt slut tid: {birth.PlannedEndDate}");
            }
        }

        public void ShowAvaliableClinciansAndRoomsForNextFiveDays()
        {
            var reservationList = _context.Reservations
                .Include(r => r.Room)
                .Include(r => r.Relatives)
                .ThenInclude(re => re.RelativesChildList)
                .ThenInclude(rc => rc.Child)
                .ThenInclude(c => c.Birth)
                .ThenInclude(b => b.WorksList)
                .ThenInclude(w => w.Clinicians)
                .Where(r => r.ReservationStartDate == DateTime.Now
                            || r.ReservationStartDate != DateTime.Now.AddDays(1)
                            || r.ReservationStartDate != DateTime.Now.AddDays(2)
                            || r.ReservationStartDate != DateTime.Now.AddDays(3)
                            || r.ReservationStartDate != DateTime.Now.AddDays(4)).ToList();

            foreach (var reservation in reservationList)
            {
                Console.WriteLine($"RumNummer: {reservation.Room.RoomNumber} " +
                                  $"\nType rum: {reservation.Room.RoomType} " +
                                  $"\nKlinikere: ??");
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
                .Where(r => r.ReservationEndDate > DateTime.Now.Date);

            foreach (var reservation in reservationList)
            {
                Console.WriteLine($"Rum Id: {reservation.RoomId} \nRum type: {reservation.Room.RoomType} \nSlut dato: {reservation.ReservationEndDate}");

                Console.WriteLine($"");
                reservation.Relatives.
                foreach (var VARIABLE in 
                {
                    
                }
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
                                      $"\nTitle: {works.Clinicians.Title}");
                }
            }
        }

        public void CloseProgram()
        {
            Environment.Exit(0);
        }
    }
}
