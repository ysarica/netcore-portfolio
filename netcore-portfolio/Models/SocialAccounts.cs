using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace netcore_portfolio.Models
{

    public partial class SocialAccounts
    {
        [Key]
        public int SocialID { get; set; }

        [StringLength(150)]
        public string SocialName { get; set; }

        public string SocialLink { get; set; }

        [StringLength(250)]
        public string SocialIcon { get; set; }

        public bool? SocialState { get; set; }
    }
}
