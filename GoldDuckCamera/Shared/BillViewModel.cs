using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Threading.Tasks;

namespace GoldDuckCamera.Shared
{
    public class BillViewModel
    {
        [Key]
        [Display(Name = "id")]
        public int id
        {
            get; set;
        }

        [Required]
        [Display(Name = "Full Name")]
        public string fullname
        {
            get; set;
        }

        [Required]
        [Display(Name = "Date")]
        public DateTime date
        {
            get; set;
        }

        [Required]
        [Display(Name = "Address")]
        public string address { get; set; }

        [Required]
        [Display(Name = "Price")]
        public int price { get; set; }

        [Required]
        [Display(Name = "User Name")]
        public string username { get; set; }

        [Required]
        [Display(Name = "Status")]
        public int status
        {
            get; set;
        }
    }
}
