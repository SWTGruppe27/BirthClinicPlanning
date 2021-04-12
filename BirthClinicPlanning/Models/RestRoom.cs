using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthClinicPlanning.Models
{
    public abstract class RestRoom : Room
    {
        public Relatives Relatives { get; set; }
        public string Type { get; set; }

        protected RestRoom()
        {
            
        }

        protected RestRoom(string type) : base(type)
        {
            RoomType = "Restroom";
        }
    }
}
