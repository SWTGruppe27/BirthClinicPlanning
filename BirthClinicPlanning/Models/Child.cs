using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using BirthClinicPlanning.Models;

namespace BirthClinicPlanning
{
    public class Child
    {
        public int CprNumber { get; set; }
        public int BirthId { get; set; }
        public DateTime Birthdate { get; set; }
        public string Gender { get; set; }
        public Birth Birth { get; set; }
        public List<RelativesChild> RelativesChild { get; set; }
    }
}
