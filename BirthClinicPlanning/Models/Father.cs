using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthClinicPlanning.Models
{
    public class Father : Relatives
    {
        public Father()
        {
        }
        public Father(string name) : base(name)
        {
            Relation = "Father";
        }

        public string CPRNumber { get; set; }
    }
}
