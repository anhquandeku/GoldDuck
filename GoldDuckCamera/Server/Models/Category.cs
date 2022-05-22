using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoldDuckCamera.Server.Models
{
    [Table("category", Schema = "dbo")]
    public class Category
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
