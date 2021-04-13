using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthClinicPlanning.Models
{
    public class Mother : Relatives
    {
        public Mother()
        {
        }
        public Mother(string name) : base(name)
        {
            Relation = "Mother";
        }
        public string CPRNumber { get; set; }
    }
}
