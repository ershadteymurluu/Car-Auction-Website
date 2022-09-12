using System.ComponentModel.DataAnnotations;

namespace MachineBazaar.Models
{
    public class Bids : BaseEntity
    {
        public int CarId { get; set; }
        public int Bid { get; set; }
        public AppUser User { get; set; }
        public Car Car { get; set; }
    }
}
