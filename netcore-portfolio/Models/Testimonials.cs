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
        public int testimonialID { get; set; }

        public int? resumeID { get; set; }

        [StringLength(250)]
        public string tName { get; set; }

        [StringLength(250)]
        public string tCoımpany { get; set; }

        public string tDescription { get; set; }

        public virtual Resume Resume { get; set; }
    }
}
