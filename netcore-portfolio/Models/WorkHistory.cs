namespace mvcSqlImporter.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WorkHistory")]
    public partial class WorkHistory
    {
        [Key]
        public int whID { get; set; }

        public int? resumeID { get; set; }

        [StringLength(50)]
        public string startDate { get; set; }

        [StringLength(50)]
        public string finishDate { get; set; }

        [StringLength(150)]
        public string workTitle { get; set; }

        [StringLength(150)]
        public string companyName { get; set; }

        public string workDescription { get; set; }

        public virtual Resume Resume { get; set; }
    }
}
