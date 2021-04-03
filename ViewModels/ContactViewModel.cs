using System.ComponentModel.DataAnnotations;

namespace Hello.ViewModel
{
    public class ContactViewModel
    {
        [Required]
        [MinLength(5)]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Its just too Long")]
        public string Reason { get; set; }
    }
}