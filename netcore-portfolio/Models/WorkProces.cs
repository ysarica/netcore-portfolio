namespace mvcSqlImporter.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class WorkProces
    {
        [Key]
        public int wpID { get; set; }

        public int? resumeID { get; set; }

        public int? wpOrder { get; set; }

        [StringLength(150)]
        public string wpName { get; set; }

        public string wpImage { get; set; }

        public virtual Resume Resume { get; set; }
    }
}
