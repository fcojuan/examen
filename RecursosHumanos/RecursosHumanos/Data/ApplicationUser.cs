using Microsoft.AspNetCore.Identity;

namespace Rinku.Data
{
    public class ApplicationUser : IdentityUser
    {
        public int IdUsuario { get; set; }
    }
}