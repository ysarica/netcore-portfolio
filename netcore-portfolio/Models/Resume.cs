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
        public Resume()
        {
            Education = new HashSet<Education>();
            Hobbies = new HashSet<Hobbies>();
            Service = new HashSet<Service>();
            Testimonials = new HashSet<Testimonials>();
            WorkHistory = new HashSet<WorkHistory>();
            WorkPartners = new HashSet<WorkPartners>();
            WorkProces = new HashSet<WorkProces>();
        }

        public int ResumeID { get; set; }

        public int? UserID { get; set; }

        public string ResumeImage { get; set; }

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

        public virtual ICollection<Education> Education { get; set; }

        public virtual ICollection<Hobbies> Hobbies { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Service> Service { get; set; }

        public virtual ICollection<Testimonials> Testimonials { get; set; }

        public virtual ICollection<WorkHistory> WorkHistory { get; set; }

        public virtual ICollection<WorkPartners> WorkPartners { get; set; }

        public virtual ICollection<WorkProces> WorkProces { get; set; }
    }
}
