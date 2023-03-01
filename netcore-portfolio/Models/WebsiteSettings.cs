namespace mvcSqlImporter.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class WebsiteSettings
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int WSID { get; set; }

        [StringLength(50)]
        public string Color { get; set; }

        [StringLength(150)]
        public string Font { get; set; }

        [StringLength(250)]
        public string Music { get; set; }

        public bool? MusicAutoPlay { get; set; }
    }
}
