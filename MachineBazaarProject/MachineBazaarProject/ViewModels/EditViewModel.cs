using MachineBazaar.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MachineBazaar.ViewModels
{
    public class EditViewModel
    {
        [Required, MaxLength(25)]
        public string UserName { get; set; }
        [Required, EmailAddress, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        [NotMapped]
        public IFormFile? Img { get; set; }
        public AppUser? User { get; set; }
    }
}
