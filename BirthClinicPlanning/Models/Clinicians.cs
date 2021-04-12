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
        public BirthRoom BirthRoom { get; set; }

        protected Clinicians(string name) : base(name)
        {
            Title = "Clinician";
        }

    }
}
