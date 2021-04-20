using System.ComponentModel.DataAnnotations;

namespace Gighub.Web.Models
{
    public class GenreModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}
