namespace mvcSqlImporter.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Education")]
    public partial class Education
    {
        public int educationID { get; set; }

        public int? resumeID { get; set; }

        [StringLength(50)]
        public string startDate { get; set; }

        [StringLength(50)]
        public string finishDate { get; set; }

        public string educationBranch { get; set; }

        public string schoolName { get; set; }

        public string educationDescription { get; set; }

        public virtual Resume Resume { get; set; }
    }
}
