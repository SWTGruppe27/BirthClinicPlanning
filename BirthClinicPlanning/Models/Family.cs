using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthClinicPlanning.Models
{
    public class Family : Relatives
    {
        public Family()
        {
        }
        public Family(string name) : base(name)
        {
            Relation = "hujisdfi";
        }

    }
}
