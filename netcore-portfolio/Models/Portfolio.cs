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
        public int pID { get; set; }

        public int? pCategoryID { get; set; }

        [StringLength(50)]
        public string pType { get; set; }

        public string pLink { get; set; }

        public string pImage { get; set; }

        [StringLength(50)]
        public string pFactoryName { get; set; }

        [StringLength(50)]
        public string pDeliveryDate { get; set; }

        public string pUseService { get; set; }

        public string pDescription { get; set; }

        public string pTitle { get; set; }

        public virtual PortfolioCategory PortfolioCategory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PortfolioImage> PortfolioImage { get; set; }
    }
}
