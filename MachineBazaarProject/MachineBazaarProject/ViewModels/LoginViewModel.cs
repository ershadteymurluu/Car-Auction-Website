using System.ComponentModel.DataAnnotations;

namespace MachineBazaar.ViewModels
{
    public class LoginViewModel
    {
        [Required, MaxLength(30)]
        public string Username { get; set; }
        [Required, MinLength(8), DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
