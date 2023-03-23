using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netcore_portfolio.Models
{
    public class Skill
    {
        public int SkillID { get; set; }

        public int? SCID { get; set; }

        public string SkillName { get; set; }

        public int? SkillDegre { get; set; }

        public  SkillCategory SkillCategory { get; set; }
    }
}
