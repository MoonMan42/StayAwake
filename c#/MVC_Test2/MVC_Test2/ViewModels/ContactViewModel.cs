using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC_Test2.ViewModels
{
    public class ContactViewModel
    {
        [Required]
        [MinLength(5, ErrorMessage = "Name must contain 5 characters!")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        [MaxLength(500, ErrorMessage = "To Long")]
        public string Message { get; set; }
    }
}
