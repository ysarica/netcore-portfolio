namespace mvcSqlImporter.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BlogComment")]
    public partial class BlogComment
    {
        public int BlogCommentID { get; set; }

        public int? BlogID { get; set; }

        [StringLength(50)]
        public string DateTime { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        public string Comment { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(250)]
        public string Website { get; set; }

        public bool? Confirmed { get; set; }

        public virtual Blog Blog { get; set; }
    }
}
