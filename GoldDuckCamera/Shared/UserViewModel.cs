using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldDuckCamera.Shared
{
    public class UserViewModel
    {

        [Key]
        [Display(Name = "User Name")]
        public string username { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string password { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string fullname { get; set; }

        [Required]
        [Display(Name = "Date")]
        public DateTime date { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public string gender { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string address { get; set; }

        [Required]
        [Display(Name = "Phone")]
        public string phone { get; set; }

        [Required]
        [Display(Name = "Permission")]
        public int idPermission { get; set; }

        [Required]
        [Display(Name = "Status")]
        public int status { get; set; }
    }
}
