namespace mvcSqlImporter.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ePortCoreDB : DbContext
    {
        public ePortCoreDB()
            : base("name=ePortCoreDB")
        {
        }

        public virtual DbSet<Blog> Blog { get; set; }
        public virtual DbSet<BlogCategory> BlogCategory { get; set; }
        public virtual DbSet<BlogComment> BlogComment { get; set; }
        public virtual DbSet<ContactMessage> ContactMessage { get; set; }
        public virtual DbSet<Education> Education { get; set; }
        public virtual DbSet<Hobbies> Hobbies { get; set; }
        public virtual DbSet<Portfolio> Portfolio { get; set; }
        public virtual DbSet<PortfolioCategory> PortfolioCategory { get; set; }
        public virtual DbSet<PortfolioImage> PortfolioImage { get; set; }
        public virtual DbSet<Resume> Resume { get; set; }
        public virtual DbSet<Service> Service { get; set; }
        public virtual DbSet<SocialAccounts> SocialAccounts { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Testimonials> Testimonials { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<WebsiteSettings> WebsiteSettings { get; set; }
        public virtual DbSet<WorkHistory> WorkHistory { get; set; }
        public virtual DbSet<WorkPartners> WorkPartners { get; set; }
        public virtual DbSet<WorkProces> WorkProces { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Resume>()
                .Property(e => e.TestimonialState)
                .IsFixedLength();
        }
    }
}
