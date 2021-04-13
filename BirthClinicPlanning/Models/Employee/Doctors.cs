using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthClinicPlanning
{
    public class Doctors : Clinicians
    {
        public Doctors()
        {
        }

        public Doctors(string name) : base(name)
        {
            Position = "Doctor";
        }
    }
}
