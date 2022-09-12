using MachineBazaar.Models;

namespace MachineBazaar.ViewModels
{
    public class HomeViewModel
    {
        public List<BodyStyle> bodyStyles { get; set; }
        public List<Transmission> transmissions { get; set; }
        public List<Year> years { get; set; }
        public List<Car> Cars { get; set; }
    }
}
