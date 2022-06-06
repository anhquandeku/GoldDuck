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
    public class BillDetailViewModel
    {
        [Key]
        [Display(Name = "idBill")]
        public int idBill
        {
            get; set;
        }
        [Required]
        [Display(Name = "idProduct")]
        public int idProduct
        {
            get; set;
        }
        [Required]
        [Display(Name = "Count")]
        public int count
        {
            get; set;
        }
    }
}
