namespace mvcSqlImporter.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Portfolio")]
    public partial class Portfolio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Portfolio()
        {
            PortfolioImage = new HashSet<PortfolioImage>();
        }

        [Key]
        public int PID { get; set; }

        public int? PCategoryID { get; set; }

        [StringLength(50)]
        public string PType { get; set; }

        public string PLink { get; set; }

        public string PImage { get; set; }

        [StringLength(50)]
        public string PFactoryName { get; set; }

        [StringLength(50)]
        public string PDeliveryDate { get; set; }

        public string PUseService { get; set; }

        public string PDescription { get; set; }

        public string PTitle { get; set; }

        public virtual PortfolioCategory PortfolioCategory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PortfolioImage> PortfolioImage { get; set; }
    }
}
