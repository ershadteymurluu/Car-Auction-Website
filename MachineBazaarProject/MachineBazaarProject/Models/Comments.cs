using System.ComponentModel.DataAnnotations;

namespace MachineBazaar.Models
{
    public class Comments : BaseEntity
    {
        public string CommentText { get; set; }
        public int CarId { get; set; }
        public AppUser User {get;set;}
        public string CommentDate { get; set; }
    }
}
