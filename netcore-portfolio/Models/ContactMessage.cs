using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace netcore_portfolio.Models
{


    [Table("ContactMessage")]
    public partial class ContactMessage
    {
        [Key]
        public int CMID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public string Message { get; set; }

        [StringLength(50)]
        public string DateTime { get; set; }

        public string Notes { get; set; }
    }
}
