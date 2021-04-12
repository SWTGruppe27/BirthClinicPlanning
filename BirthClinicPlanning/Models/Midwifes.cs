using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthClinicPlanning
{
    public class Midwifes : Clinicians
    {
        public Midwifes()
        {
        }

        public Midwifes(string name) : base(name)
        {
            Position = "Midwife";
        }
    }
}
