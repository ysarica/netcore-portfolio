namespace mvcSqlImporter.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Hobbies
    {
        [Key]
        public int hobbieID { get; set; }

        public int? resumeID { get; set; }

        [StringLength(150)]
        public string hobbieName { get; set; }

        public string hobbieImage { get; set; }

        public virtual Resume Resume { get; set; }
    }
}
