using System.ComponentModel.DataAnnotations.Schema;

namespace MachineBazaar.Models
{
    public class CarImage : BaseEntity
    {
        public int CarId { get; set; }
        public string imagePath { get; set; }
        public Car Car { get; set; }
    }
}
