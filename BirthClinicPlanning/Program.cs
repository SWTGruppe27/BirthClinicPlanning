using System;
using System.Reflection.PortableExecutable;
using BirthClinicPlanning.Data;
using BirthClinicPlanning.Models;

namespace BirthClinicPlanning
{
    class Program
    {
        static void Main(string[] args)
        {

            //BirthRoom b = new BirthRoom();

            //Console.WriteLine($"{b.RoomType}");

            //MaternityRoom f = new MaternityRoom();

            //Console.WriteLine($"{f.RoomType}, {f.Type}");

            using (BirthClinicPlanningContext context = new BirthClinicPlanningContext())
            {

                Father f1 = new Father("Hans Hansen");
                f1.CPRNumber = "sdf";

                context.Add(f1);

                //context.Add(n1);
                context.SaveChanges();
            }

        }
    }
}
