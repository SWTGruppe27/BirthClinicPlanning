using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthClinicPlanning.Models
{
    public abstract class Room
    {
        public int RoomNumber { get; set; }
        public string RoomType { get; set; }

        public List<Reservation> ReservationList { get; set; }
        protected Room()
        {

        }

        protected Room(string roomType)
        {
            RoomType = roomType;
        }
    }
}
