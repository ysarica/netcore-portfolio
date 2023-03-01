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
        public int serviceID { get; set; }

        public int? resumeID { get; set; }

        [StringLength(150)]
        public string serviceName { get; set; }

        public string serviceDescription { get; set; }

        public virtual Resume Resume { get; set; }
    }
}
