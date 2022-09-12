using MachineBazaar.Models;
using System.ComponentModel.DataAnnotations;

namespace MachineBazaar.ViewModels
{
    public class CommentViewModel
    {
        public Car? Car { get; set; }
        [Required(ErrorMessage = "can't add an empty comment")]
        public string CommentText { get; set; }
        public int GetCarId { get; set; }
    }
}
