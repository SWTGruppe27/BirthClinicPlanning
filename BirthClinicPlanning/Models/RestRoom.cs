using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthClinicPlanning.Models
{
    public abstract class RestRoom : Room
    {
        public string Type { get; set; }
        public DateTime OccupiedStart { get; set; }
        public DateTime OccupiedEnd { get; set; }
        protected RestRoom()
        {
            RoomType = "Restroom";
        }
    }
}
