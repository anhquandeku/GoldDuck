using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoldDuckCamera.Server.Models
{
    [Table("bill", Schema = "dbo")]
    public class Bill
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        public string fullname { get; set; }

        [Required]
        public DateTime date { get; set; }

        [Required]
        public string address { get; set; }

        [Required]
        public int price { get; set; }

        [Required]
        public string username { get; set; }

        [Required]
        public int status { get; set; }
    }
}
