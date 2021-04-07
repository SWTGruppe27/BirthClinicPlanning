using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthClinicPlanning.Models
{
    public class BirthRoom : Room
    {
        public Birth Birth { get; set; }
    }
}
