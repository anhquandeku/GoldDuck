using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldDuckCamera.Shared
{
    public class ProductViewModel
    {

        [Key]
        [Display(Name = "Id")]
        public int id { get; set; }

        [Required]
        [Display(Name = "Img 1")]
        public string img1 { get; set; }

        [Required]
        [Display(Name = "Img 2")]
        public string img2 { get; set; }

        [Display(Name = "Id Category")]
        public int idCategory { get; set; }

        [Required]
        [Display(Name = "Price")]
        public int price { get; set; }

        [Required]
        [Display(Name = "Cost")]
        public int cost { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string name { get; set; }

        [Display(Name = "Id Brand")]
        public int idBrand { get; set; }

        [Required]
        [Display(Name = "Date")]
        public DateTime date { get; set; }

        [Required]
        [Display(Name = "Count")]
        public int count { get; set; }

        [Required]
        [Display(Name = "Sold")]
        public int sold { get; set; }

        [Required]
        [Display(Name = "Sale")]
        public int sale { get; set; }

        [Display(Name = "Guarantee")]
        public int guarantee { get; set; }

        [Display(Name = "Specifications")]
        public string specifications { get; set; }

        [Required]
        [Display(Name = "Status")]
        public int status { get; set; }
    }
}
