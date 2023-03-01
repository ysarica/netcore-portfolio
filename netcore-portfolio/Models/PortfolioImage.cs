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
        public int pImageID { get; set; }

        public string pImage { get; set; }

        public int? pID { get; set; }

        public virtual Portfolio Portfolio { get; set; }
    }
}
