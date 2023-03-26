using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace netcore_portfolio.Models
{


    [Table("Resume")]
    public partial class Resume
    {

        public int ResumeID { get; set; }

        [StringLength(150)]
        public string Title { get; set; }
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Surname { get; set; }

        public string TitleDescription { get; set; }

        [StringLength(50)]
        public string Mail { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        public string ResumeImage { get; set; }
        [StringLength(50)]
        public string Location { get; set; }

        public string ResumeAbout { get; set; }

        public string PdfCV { get; set; }

        public bool? WorkState { get; set; }

        public bool? ServiceState { get; set; }

        public bool? WorkProccesState { get; set; }

        public bool? WorkPartnersState { get; set; }

        public bool? HobbiesState { get; set; }

        public bool? WorkHistoryState { get; set; }

        public bool? EducationState { get; set; }

        public bool? TestimonialState { get; set; }
        public bool? SkillCategoryState { get; set; }


        public virtual ICollection<Education> Education { get; set; }

        public virtual ICollection<Hobbies> Hobbies { get; set; }

        public virtual ICollection<Service> Service { get; set; }

        public virtual ICollection<Testimonials> Testimonials { get; set; }

        public virtual ICollection<WorkHistory> WorkHistory { get; set; }

        public virtual ICollection<WorkPartners> WorkPartners { get; set; }

        public virtual ICollection<WorkProces> WorkProces { get; set; }
        public virtual ICollection<SkillCategory> SkillCategory { get; set; }

    }
}
