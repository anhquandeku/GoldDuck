using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;

namespace GoldDuckCamera.Shared
{
    public class BrandViewModel
    {
        [Key]
        [Display(Name = "id")]
        public int id
        {
            get; set;
        }
        [Required]
        [Display(Name = "Name")]
        public string name
        {
            get; set;
        }
        [Required]
        [Display(Name = "Status")]
        public int status
        {
            get; set;
        }
    }
}
