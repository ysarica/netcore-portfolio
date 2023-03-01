namespace mvcSqlImporter.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Testimonials
    {
        [Key]
        public int TestimonialID { get; set; }

        public int? ResumeID { get; set; }

        [StringLength(250)]
        public string TName { get; set; }

        [StringLength(250)]
        public string TCoımpany { get; set; }

        public string TDescription { get; set; }

        public virtual Resume Resume { get; set; }
    }
}
