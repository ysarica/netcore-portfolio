using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace netcore_portfolio.Models
{

    [Table("WorkHistory")]
    public partial class WorkHistory
    {
        public int WorkHistoryID { get; set; }

        public int? ResumeID { get; set; }

        [StringLength(50)]
        public string StartDate { get; set; }

        [StringLength(50)]
        public string FinishDate { get; set; }

        [StringLength(150)]
        public string WorkTitle { get; set; }

        [StringLength(150)]
        public string CompanyName { get; set; }

        public string WorkDescription { get; set; }

        public virtual Resume Resume { get; set; }
    }
}
