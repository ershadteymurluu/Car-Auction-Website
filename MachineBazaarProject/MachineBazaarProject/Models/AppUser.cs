using Microsoft.AspNetCore.Identity;

namespace MachineBazaar.Models
{
    public class AppUser : IdentityUser
    {
        public string ProfilePicture { get; set; }
        public string JoinDate { get; set; }
        public List<Car> Cars { get; set; }
        public List<Bids> MyBids { get; set; }
    }
}
