using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoldDuckCamera.Server.Models
{
    [Table("product", Schema = "dbo")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        public string img1 { get; set; }

        [Required]
        public string img2 { get; set; }
        public int idCategory { get; set; }

        [Required]
        public int price { get; set; }

        [Required]
        public int cost { get; set; }

        [Required]
        public string name { get; set; }
        public int idBrand { get; set; }

        [Required]
        public DateTime date { get; set; }

        [Required]
        public int count { get; set; }

        [Required]
        public int sold { get; set; }

        [Required]
        public int sale { get; set; }
        public int guarantee { get; set; }
        public string specifications { get; set; }

        [Required]
        public int status { get; set; }
    }
}
