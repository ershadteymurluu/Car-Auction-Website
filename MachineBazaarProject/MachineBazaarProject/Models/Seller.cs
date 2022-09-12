namespace MachineBazaar.Models
{
    public class Seller : BaseEntity
    {
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public List<Car> Cars { get; set; }
    }
}
