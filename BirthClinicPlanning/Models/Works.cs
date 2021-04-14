using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthClinicPlanning.Models
{
    public class Works
    {
        public int WorksId { get; set; }
        public int? BirthId { get; set; }
        public Birth Birth { get; set; }
        public int? EmployeeId { get; set; }
        public Clinicians Clinicians { get; set; }
    }
}
