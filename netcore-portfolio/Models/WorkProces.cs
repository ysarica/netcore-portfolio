using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace netcore_portfolio.Models
{

    public partial class WorkProces
    {
        [Key]
        public int WorkProcesID { get; set; }

        public int? ResumeID { get; set; }

        public int? WpOrder { get; set; }

        [StringLength(150)]
        public string WpName { get; set; }

        public string WpImage { get; set; }

        public virtual Resume Resume { get; set; }
    }
}
