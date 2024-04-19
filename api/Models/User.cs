using Microsoft.AspNetCore.Identity;

namespace api.Models
{
    public class User : IdentityUser
    {
        //public int PortfolioId { get; set; }
        public Portfolio? Portfolio { get; set; }
    }
}
