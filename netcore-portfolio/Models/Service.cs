using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace netcore_portfolio.Models
{

    [Table("Service")]
    public partial class Service
    {
        public int ServiceID { get; set; }

        public int? ResumeID { get; set; }

        [StringLength(150)]
        public string ServiceName { get; set; }

        public string ServiceDescription { get; set; }

        public string ServiceImage { get; set; }

        public virtual Resume Resume { get; set; }
    }
}
