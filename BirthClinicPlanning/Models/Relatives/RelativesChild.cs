using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthClinicPlanning.Models
{
    public class RelativesChild
    {
        public int RelativesChildId { get; set; }
        public int RelativesId { get; set; }
        public Relatives Relatives { get; set; }
        public int ChildId { get; set; }
        public Child Child { get; set; }
    }
}
