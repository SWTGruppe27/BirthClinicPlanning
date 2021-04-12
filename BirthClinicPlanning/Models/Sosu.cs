using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthClinicPlanning
{
    public class Sosu : Clinicians 
    {
        public Sosu(string name) : base(name)
        {
            Position = "Sosu";
        }
    }
}
