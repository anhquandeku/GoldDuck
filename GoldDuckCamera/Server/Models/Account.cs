using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GoldDuckCamera.Server.Models
{

    public class Account: IdentityUser<Guid>
    {
        public Account()
        {
        }
        public string Permission
        {
            get; set;
        }
        
    }
}
