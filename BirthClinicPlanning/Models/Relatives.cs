using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthClinicPlanning.Models
{
    public abstract class Relatives
    {
        protected Relatives()
        {
        }

        protected Relatives(string name)
        {
            FullName = name;
        }

        public int RelativesId { get; set; }
        public int RestRoomId { get; set; }
        public string FullName { get; set; }
        public string Relation { get; set; }
        public List<Reservation> ReservationList { get; set; }
        public List<RelativesChild> RelativesChildList { get; set; }
    }
}
