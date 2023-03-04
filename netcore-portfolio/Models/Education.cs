using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace netcore_portfolio.Models
{
  

    [Table("Education")]
    public partial class Education
    {
        public int EducationID { get; set; }

        public int? ResumeID { get; set; }

        [StringLength(50)]
        public string StartDate { get; set; }

        [StringLength(50)]
        public string FinishDate { get; set; }

        public string EducationBranch { get; set; }

        public string SchoolName { get; set; }

        public string EducationDescription { get; set; }

        public virtual Resume Resume { get; set; }
    }
}
