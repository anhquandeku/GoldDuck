using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoldDuckCamera.Server.Models
{
    [Table("user", Schema = "dbo")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string username { get; set; }

        [Required]
        public string password { get; set; }

        [Required]
        public string fullname { get; set; }

        [Required]
        public DateTime date { get; set; }

        [Required]
        public string gender { get; set; }

        [Required]
        public string address { get; set; }

        [Required]
        public string phone { get; set; }

        [Required]
        public int idPermission { get; set; }

        [Required]
        public int status { get; set; }
    }
}
