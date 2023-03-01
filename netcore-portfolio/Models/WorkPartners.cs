namespace mvcSqlImporter.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class WorkPartners
    {
        [Key]
        public int wpsID { get; set; }

        public int? resumeID { get; set; }

        public string wpsLogo { get; set; }

        [StringLength(150)]
        public string wpsName { get; set; }

        public virtual Resume Resume { get; set; }
    }
}
