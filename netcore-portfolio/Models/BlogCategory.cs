using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace netcore_portfolio.Models
{


    [Table("BlogCategory")]
    public partial class BlogCategory
    {
        public BlogCategory()
        {
            Blog = new HashSet<Blog>();
        }

        public int BlogCategoryID { get; set; }

        [StringLength(150)]
        public string BlogCategoryName { get; set; }

        public bool? BlogCategoryState { get; set; }

        public virtual ICollection<Blog> Blog { get; set; }
    }
}
