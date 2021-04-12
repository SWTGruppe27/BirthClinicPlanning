using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthClinicPlanning.Models
{
    public class BirthRoom : Room
    {
        public int BirthId { get; set; }
        public int EmployeeId { get; set; }
        public Birth Birth { get; set; }
        public List<Clinicians> CliniciansList { get; set; }

        public BirthRoom()
        {
            RoomType = "BirthRoom";
        }
    }
}
