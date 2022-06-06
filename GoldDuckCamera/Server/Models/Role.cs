using Microsoft.AspNetCore.Identity;

namespace GoldDuckCamera.Server.Models
{
    public class Role: IdentityRole<Guid>
    {
        public string description
        {
            get; set;
        }
    }
}
