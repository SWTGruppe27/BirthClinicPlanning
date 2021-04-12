using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BirthClinicPlanning.Models;

namespace BirthClinicPlanning
{
    public class MaternityRoom : RestRoom
    {
        public MaternityRoom()
        {

        }

        public MaternityRoom(string type) : base(type)
        {
            RoomType = "MaternityRoom";
        }
    }
}
