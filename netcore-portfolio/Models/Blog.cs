namespace mvcSqlImporter.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Blog")]
    public partial class Blog
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Blog()
        {
            BlogComment = new HashSet<BlogComment>();
        }

        public int BlogID { get; set; }

        public int? BlogCategoryID { get; set; }

        public string BlogTitle { get; set; }

        [StringLength(50)]
        public string BlogType { get; set; }

        [StringLength(50)]
        public string BlogDate { get; set; }

        public string BlogDescription { get; set; }

        public bool? BlogState { get; set; }

        public string BlogImage { get; set; }

        public virtual BlogCategory BlogCategory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BlogComment> BlogComment { get; set; }
    }
}
