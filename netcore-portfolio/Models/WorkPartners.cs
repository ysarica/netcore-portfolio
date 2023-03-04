using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace netcore_portfolio.Models
{

    public partial class WorkPartners
    {
        public int WorkPartnersID { get; set; }

        public int? ResumeID { get; set; }

        public string WpsLogo { get; set; }

        [StringLength(150)]
        public string WpsName { get; set; }

        public virtual Resume Resume { get; set; }
    }
}
