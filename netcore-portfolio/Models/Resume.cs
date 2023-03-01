namespace mvcSqlImporter.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Resume")]
    public partial class Resume
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Resume()
        {
            Education = new HashSet<Education>();
            Hobbies = new HashSet<Hobbies>();
            Service = new HashSet<Service>();
            Testimonials = new HashSet<Testimonials>();
            WorkHistory = new HashSet<WorkHistory>();
            WorkPartners = new HashSet<WorkPartners>();
            WorkProces = new HashSet<WorkProces>();
        }

        public int resumeID { get; set; }

        public int? UserID { get; set; }

        public string resumeImage { get; set; }

        public string resumeAbout { get; set; }

        public string pdfCV { get; set; }

        public bool? workState { get; set; }

        public bool? serviceState { get; set; }

        public bool? workProccesState { get; set; }

        public bool? workPartnersState { get; set; }

        public bool? hobbiesState { get; set; }

        public bool? workHistoryState { get; set; }

        public bool? educationState { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Education> Education { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hobbies> Hobbies { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Service> Service { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Testimonials> Testimonials { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorkHistory> WorkHistory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorkPartners> WorkPartners { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorkProces> WorkProces { get; set; }
    }
}
