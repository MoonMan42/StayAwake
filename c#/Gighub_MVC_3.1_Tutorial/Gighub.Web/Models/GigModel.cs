using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gighub.Web.Models
{
    public class GigModel
    {
        public int Id { get; set; }
        public string ArtisitId { get; set; }
        public DateTime DateTime { get; set; }
        public string Venue { get; set; }
        public GenreModel Genre { get; set; }
    }
}
