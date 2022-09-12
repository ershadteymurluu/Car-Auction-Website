using MachineBazaar.Models;
using System.ComponentModel.DataAnnotations;

namespace MachineBazaar.ViewModels
{
    public class RegisterViewModel
    {
        [Required, MaxLength(25)]
        public string UserName { get; set; }
        [Required, EmailAddress, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required, MinLength(8), DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, Compare(nameof(Password))]
        public string RepeatPassword { get; set; }
        [Required]
        public int PhoneNumber { get; set; }
    }
}
