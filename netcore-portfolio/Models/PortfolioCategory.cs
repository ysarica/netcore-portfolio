using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace netcore_portfolio.Models
{


    [Table("PortfolioCategory")]
    public partial class PortfolioCategory
    {
        public PortfolioCategory()
        {
            Portfolio = new HashSet<Portfolio>();
        }

        [Key]
        public int PCategoryID { get; set; }

        [StringLength(250)]
        public string PCategoryName { get; set; }

        public  ICollection<Portfolio> Portfolio { get; set; }
    }
}
