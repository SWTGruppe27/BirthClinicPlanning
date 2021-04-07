using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthClinicPlanning.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Title { get; set; } //Secretarie og clinician
        public string FullName { get; set; }
    }
}
