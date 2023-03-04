using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;    

namespace netcore_portfolio.Models
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-H96T0HB\\SQLEXPRESS;database=CorePortDB; integrated security=true;");
        }
        public  DbSet<Blog> Blog { get; set; }
        public  DbSet<BlogCategory> BlogCategory { get; set; }
        public  DbSet<BlogComment> BlogComment { get; set; }
        public  DbSet<ContactMessage> ContactMessage { get; set; }
        public  DbSet<Education> Education { get; set; }
        public  DbSet<Hobbies> Hobbies { get; set; }
        public  DbSet<Portfolio> Portfolio { get; set; }
        public  DbSet<PortfolioCategory> PortfolioCategory { get; set; }
        public  DbSet<PortfolioImage> PortfolioImage { get; set; }
        public  DbSet<Resume> Resume { get; set; }
        public  DbSet<Service> Service { get; set; }
        public  DbSet<SocialAccounts> SocialAccounts { get; set; }
        public  DbSet<Testimonials> Testimonials { get; set; }
        public  DbSet<User> User { get; set; }
        public  DbSet<WebsiteSettings> WebsiteSettings { get; set; }
        public  DbSet<WorkHistory> WorkHistory { get; set; }
        public  DbSet<WorkPartners> WorkPartners { get; set; }
        public  DbSet<WorkProces> WorkProces { get; set; }
    }
}
