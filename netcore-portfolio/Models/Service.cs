namespace mvcSqlImporter.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Service")]
    public partial class Service
    {
        public int ServiceID { get; set; }

        public int? ResumeID { get; set; }

        [StringLength(150)]
        public string ServiceName { get; set; }

        public string ServiceDescription { get; set; }

        public virtual Resume Resume { get; set; }
    }
}
