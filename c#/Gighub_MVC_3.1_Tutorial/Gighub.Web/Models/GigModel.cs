using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gighub.Web.Models
{
    public class GigModel
    {
        public int Id { get; set; }

        [Required]
        public string ArtisitId { get; set; }


        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(255)]
        public string Venue { get; set; }

        [Required]
        public GenreModel Genre { get; set; }
    }
}
