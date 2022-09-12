using MachineBazaar.Models;
using System.ComponentModel.DataAnnotations;

namespace MachineBazaar.ViewModels
{
    public class BidViewModel
    {
        public Car? Car { get; set; }
        [Required(ErrorMessage = "Please, add your bid first.")]
        public string? Bid { get; set; }

        public int GetCarId { get; set; }

    }
}
