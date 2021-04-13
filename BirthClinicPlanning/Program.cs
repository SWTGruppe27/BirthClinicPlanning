using System;
using System.Diagnostics;
using System.Reflection.PortableExecutable;
using BirthClinicPlanning.Data;
using BirthClinicPlanning.Models;

namespace BirthClinicPlanning
{
    class Program
    {
        static void Main(string[] args)
        {
            //using (BirthClinicPlanningContext context = new BirthClinicPlanningContext())
            //{
            //    Birth b1 = new Birth();
            //    b1.PlannedStartDate = DateTime.Now;
            //    b1.PlannedEndDate = DateTime.Now.AddDays(1);

            //    Birth b2 = new Birth();
            //    b2.PlannedStartDate = DateTime.Now.AddDays(4);
            //    b2.PlannedEndDate = DateTime.Now.AddDays(5);

            //    Mother m1 = new Mother("Simone Schou Jensen");
            //    Father f1 = new Father("Simon Bjermand Kjær");

            //    Child c1 = new Child();
            //    c1.Birth = b1;

            //    RelativesChild rc1 = new RelativesChild();
            //    rc1.Child = c1;
            //    rc1.Relatives = m1;

            //    Works w1 = new Works();
            //    w1.Birth = b1;
            //    w1.EmployeeId = 27;

            //    Reservation r1 = new Reservation();
            //    r1.Relatives = m1;

            //    r1.RoomId = 28;

            //    context.Add(b1);
            //    context.Add(b2);
            //    context.Add(m1);
            //    context.Add(f1);
            //    context.Add(c1);
            //    context.Add(rc1);
            //    context.Add(w1);
            //    context.Add(r1);

            //    context.SaveChanges();
            //}

            DatabaseSearch dbSearch = new DatabaseSearch(new BirthClinicPlanningContext());

            Console.WriteLine("Velkommen til BirthClinicPlanning!\n");

            Console.WriteLine("Vælg en af følgende muligheder: ");
            Console.WriteLine("1. Vis planlagte fødsler");
            Console.WriteLine("2. Vis ledige rum for de kommende fire dage");
            Console.WriteLine("3. Vis information om igangværende fødsler");
            Console.WriteLine("4. Vis information om hvilerum i brug");
            Console.WriteLine("5. Vis reserverede fødselsrum");
            Console.WriteLine("6. Vis klinikere tilkoblet fødsler");
            Console.WriteLine("7. Luk programmet\n");

            string input = Console.ReadLine();

            //while (int.Parse(input) < 0 || int.Parse(input) > 8)
            //{
            //    Console.WriteLine("Forkert input. Vælg et tal mellem 1 og 7.");
            //    input = Console.ReadLine();
            //}

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
                    dbSearch.ShowReservedRooms(id1);
                    break;

                case 6:
                    Console.WriteLine("Indtast fødsels id:");
                    int id2 = int.Parse(Console.ReadLine());
                    dbSearch.ShowCliniciansAssignedBirths(id2);
                    break;

                case 7:
                    dbSearch.CloseProgram();
                    break;

                default:
                    break;
            }

        }
    }
}
