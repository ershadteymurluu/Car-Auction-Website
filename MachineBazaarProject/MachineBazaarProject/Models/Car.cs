using System.ComponentModel.DataAnnotations.Schema;

namespace MachineBazaar.Models
{
    public class Car : BaseEntity
    {
        public string City { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int YearId { get; set; }
        public int Mileage { get; set; }
        public int MotorSizeId { get; set; }
        public string Hp { get; set; }
        public int AuctionStartingPrice { get; set; }
        public int TransmissionId { get; set; }
        public int FuelTypeId { get; set; }
        public int BodyStyleId { get; set; }
        public string SellerNote { get; set; }
        public AppUser AppUser { get; set; }
        public List<CarImage> Images { get; set; }
        public FuelType FuelType { get; set; }
        public Transmission Transmission { get; set; }
        public BodyStyle BodyStyle { get; set; }
        public MotorSize MotorSize { get; set; }
        public List<Comments> Comments { get; set; }
        public Year Year { get; set; }
        public List<Bids> CarBids { get; set; }

        public bool Status { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime Created { get; set; }

    }
}
