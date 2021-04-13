using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthClinicPlanning
{
    public class Nurses : Clinicians
    {
        public Nurses()
        {
        }

        public Nurses(string name) : base(name)
        {
            Position = "Nurse";
        }
    }
}
