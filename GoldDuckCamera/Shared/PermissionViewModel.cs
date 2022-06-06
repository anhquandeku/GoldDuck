using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GoldDuckCamera.Shared
{
    public class PermissionViewModel
    {

        [Key]
        [Display(Name = "Id")]
        public int id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string name { get; set; }

        [Required]
        [Display(Name = "Status")]
        public int status { get; set; }
    }
}
