using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthClinicPlanning.Models
{
    public class Secretaries : Employee
    {
        public Secretaries(string name) : base(name)
        {
            Title = "Secretary";
        }
    }
}
