namespace mvcSqlImporter.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class WorkProces
    {
        public int WorkProcesID { get; set; }

        public int? ResumeID { get; set; }

        public int? WpOrder { get; set; }

        [StringLength(150)]
        public string WpName { get; set; }

        public string WpImage { get; set; }

        public virtual Resume Resume { get; set; }
    }
}
