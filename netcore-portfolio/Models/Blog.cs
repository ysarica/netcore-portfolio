
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace netcore_portfolio.Models
{


    [Table("Blog")]
    public partial class Blog
    {
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

        public virtual ICollection<BlogComment> BlogComment { get; set; }
    }
}
