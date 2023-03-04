using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace netcore_portfolio.Models
{

    [Table("User")]
    public partial class User
    {
        public User()
        {
            Resume = new HashSet<Resume>();
        }

        public int UserID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Surname { get; set; }

        [StringLength(150)]
        public string Title { get; set; }

        public string TitleDescription { get; set; }

        [StringLength(50)]
        public string Mail { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        public string UserImage { get; set; }

        public string Password { get; set; }

        [StringLength(50)]
        public string Location { get; set; }

        public virtual ICollection<Resume> Resume { get; set; }
    }
}
