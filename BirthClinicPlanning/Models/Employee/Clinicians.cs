using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BirthClinicPlanning.Models;

namespace BirthClinicPlanning
{
    public abstract class Clinicians : Employee
    {
        public string Position { get; set; }
        public int BirthRoomId { get; set; }
        public List<Works> WorksList  { get; set; }

        protected Clinicians()
        {
        }

        protected Clinicians(string name) : base(name)
        {
            Title = "Clinician";
        }

    }
}
