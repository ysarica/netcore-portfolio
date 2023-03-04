using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace netcore_portfolio.Models
{

    public partial class Hobbies
    {
        [Key]
        public int HobbieID { get; set; }

        public int? ResumeID { get; set; }

        [StringLength(150)]
        public string HobbieName { get; set; }

        public string HobbieImage { get; set; }

        public virtual Resume Resume { get; set; }
    }
}
