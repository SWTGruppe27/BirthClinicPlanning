using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.PortableExecutable;
using BirthClinicPlanning.Data;
using BirthClinicPlanning.Models;

namespace BirthClinicPlanning
{
    class Program
    {
        static void Main(string[] args)
        {
            //AddData();

            BirthClinicPlanningContext context = new BirthClinicPlanningContext();

            DatabaseSearch dbSearch = new DatabaseSearch(context);
            DatabaseAlterData dbAlter = new DatabaseAlterData(context);

            bool running = true;

            Console.WriteLine("Velkommen til BirthClinicPlanning!\n");

            while (running)
            {
                Console.WriteLine("Vælg en af følgende muligheder: ");
                Console.WriteLine("1. Vis planlagte fødsler");
                Console.WriteLine("2. Vis ledige rum for de kommende fire dage");
                Console.WriteLine("3. Vis information om igangværende fødsler");
                Console.WriteLine("4. Vis information om hvilerum i brug");
                Console.WriteLine("5. Vis reserverede fødselsrum");
                Console.WriteLine("6. Vis klinikere tilkoblet fødsler");
                Console.WriteLine("7. Marker en fødsel som færdig");
                Console.WriteLine("8. Annuller en reservation på et rum");
                Console.WriteLine("9. Luk programmet\n");

                string input = Console.ReadLine();

                switch (int.Parse(input))
                {
                    case 1:
                        dbSearch.ShowPlannedBirths();
                        break;

                    case 2:
                        dbSearch.ShowAvaliableClinciansAndRoomsForNextFiveDays();
                        break;

                    case 3:
                        dbSearch.ShowInfoAboutOngoingBirths();
                        break;

                    case 4:
                        dbSearch.ShowInfoAboutRestRoomsInUse();
                        break;

                    case 5:
                        Console.WriteLine("Indtast fødsels id:");
                        int id1 = int.Parse(Console.ReadLine());
                        Console.WriteLine("");
                        dbSearch.ShowReservedRooms(id1);
                        break;

                    case 6:
                        Console.WriteLine("Indtast fødsels id:");
                        int id2 = int.Parse(Console.ReadLine());
                        Console.WriteLine("");
                        dbSearch.ShowCliniciansAssignedBirths(id2);
                        break;

                    case 7:
                        Console.WriteLine("Indtast fødsels id:");
                        int id3 = int.Parse(Console.ReadLine());
                        dbAlter.EndBirth(id3);
                        break;

                    case 8:
                        Console.WriteLine("Indtast reservations id:");
                        int id4 = int.Parse(Console.ReadLine());
                        dbAlter.CancelReservation(id4);
                        break;

                    case 9:
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Forkert input. Vælg et tal mellem 1 og 7.\n");
                        break;
                }
            }

        }

        static void AddData()
        {
            using (BirthClinicPlanningContext context = new BirthClinicPlanningContext())
            {
                Birth b1 = new Birth();
                b1.PlannedStartDate = DateTime.Now;
                b1.PlannedEndDate = DateTime.Now.AddDays(1);

                Birth b2 = new Birth();
                b2.PlannedStartDate = DateTime.Now.AddDays(4);
                b2.PlannedEndDate = DateTime.Now.AddDays(5);

                Birth b3 = new Birth();
                b3.PlannedStartDate = DateTime.Now.AddDays(1);
                b3.PlannedEndDate = DateTime.Now.AddDays(2);

                Mother m1 = new Mother("Simone Schou Jensen");
                Father f1 = new Father("Simon Bjermand Kjær");

                Child c1 = new Child();
                c1.Birth = b1;

                RelativesChild rc1 = new RelativesChild();
                rc1.Child = c1;
                rc1.Relatives = m1;

                Works w1 = new Works();
                w1.Birth = b1;
                w1.EmployeeId = 27;

                Clinicians e1 = context.Clinicians.Find(27);

                e1.BirthRoomId = 1;

                context.Update(e1);

                Clinicians e2 = context.Clinicians.Find(1);

                e2.BirthRoomId = 2;

                context.Update(e1);

                Works w2 = new Works();
                w2.Birth = b2;
                w2.EmployeeId = 1;

                Reservation r1 = context.Reservations.Find(28);
                r1.Relatives = m1;
                r1.ReservationStartDate = DateTime.Now;
                r1.ReservationEndDate = DateTime.Now.AddDays(2);

                r1.RoomId = 28;

                context.Update(r1);

                Reservation r2 = context.Reservations.Find(1);
                r2.Relatives = m1;
                r2.ReservationStartDate = DateTime.Now.AddDays(2);
                r2.ReservationEndDate = DateTime.Now.AddDays(3);

                r2.RoomId = 1;

                context.Update(r2);

                Reservation r3 = context.Reservations.Find(13);
                r3.Relatives = m1;
                r3.ReservationStartDate = DateTime.Now;
                r3.ReservationEndDate = DateTime.Now.AddDays(3);

                r3.RoomId = 13;

                context.Update(r3);

                context.Add(b1);
                context.Add(b2);
                context.Add(b3);
                context.Add(c1);
                context.Add(m1);
                context.Add(f1);
                context.Add(rc1);
                context.Add(w1);
                context.Add(w2);

                context.SaveChanges();

            }
        }
    }
}
