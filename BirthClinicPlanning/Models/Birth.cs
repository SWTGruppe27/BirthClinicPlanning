using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BirthClinicPlanning.Models;

namespace BirthClinicPlanning
{
    public class Birth
    {
        public int BirthId { get; set; }
        public DateTime PlannedStartDate { get; set; }
        public DateTime PlannedEndDate { get; set; }
        public List<Works> WorksList { get; set; }
        public List<Child> ChildList { get; set; }
    }
}
