using MachineBazaar.Models;
using System.ComponentModel.DataAnnotations;

namespace MachineBazaar.ViewModels
{
    public class SellCarViewModel
    {
        [Required(ErrorMessage = "Please, mention where your car is.")]
        public string City { get; set; }


        [Required(ErrorMessage = "Please, mention car's make")]
        public string Make { get; set; }


        [Required(ErrorMessage = "Please, mention car's model")]
        public string Model { get; set; }



        [Required(ErrorMessage = "Please, mention car's mileage")]
        public string Mileage { get; set; }


        [Required, Range(0, int.MaxValue, ErrorMessage = "Please choose a motor size")]
        public int GetMotorSizeId { get; set; }


        [Required(ErrorMessage = "Please, mention car's horse power")]
        public string Hp { get; set; }


        [Required(ErrorMessage = "Please, mention car's starting auction price")]
        public string AuctionStartingPrice { get; set; }



        [Required, Range(0, int.MaxValue, ErrorMessage = "Please choose a year")]
        public int GetYearId { get; set; }



        [Required, Range(0, int.MaxValue, ErrorMessage = "Please choose a transmission type")]
        public int GetTransmissionId { get; set; }



        [Required, Range(0, int.MaxValue, ErrorMessage = "Please choose a fuel type")]
        public int GetFuelTypeId { get; set; }


        [Required, Range(0, int.MaxValue, ErrorMessage = "Please choose a body style")]
        public int GetBodyStyleId { get; set; }
        [Required(ErrorMessage = "Please, add your note about the car you want to sell.")]
        public string SellerNote { get; set; }


        public List<Year>? Years { get; set; }
        public List<Transmission>? Transmissions { get; set; }
        public List<BodyStyle>? BodyStyles { get; set; }
        public List<FuelType>? FuelTypes { get; set; }

        public List<MotorSize>? MotorSizes { get; set; }

        [Required(ErrorMessage = "Please, add images that highlights car's exterior, interior etc.")]
        public List<IFormFile> CarImages { get; set; }
    }
}
