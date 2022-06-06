using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoldDuckCamera.Server.Models
{
    [Table("billdetail", Schema = "dbo")]
    public class BillDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idBill { get; set; }

        [Required]
        public int idProduct { get; set; }

        [Required]
        public int count { get; set; }
    }
}
