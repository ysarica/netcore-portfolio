using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace netcore_portfolio.Models
{
    public class SkillCategory
    {
        [Key]
        public int SCID { get; set; }

        public string SCName { get; set; }

        public int? ResumeID { get; set; }

        public virtual Resume Resume { get; set; }

        public virtual ICollection<Skill> Skill { get; set; }
    }
}
