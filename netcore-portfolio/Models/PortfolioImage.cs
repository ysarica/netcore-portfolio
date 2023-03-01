namespace mvcSqlImporter.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PortfolioImage")]
    public partial class PortfolioImage
    {
        [Key]
        public int PImageID { get; set; }

        public string PImage { get; set; }

        public int? PID { get; set; }

        public virtual Portfolio Portfolio { get; set; }
    }
}
