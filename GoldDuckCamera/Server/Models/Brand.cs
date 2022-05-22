using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoldDuckCamera.Server.Models
{
    [Table("brand", Schema = "dbo")]
    public class Brand
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id
        {
            get; set;
        }
        [Required]
        public string name
        {
            get; set;
        }
        [Required]
        public int status
        {
            get; set;
        }
    }
}
