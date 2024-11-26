using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Models
{
    public class servedhall
    {
        public int Id { get; set; }
        public ICollection<seats> seats { get; set; }
        public movie movie { get; set; }
        [ForeignKey("movie")]
        public int movie_id { get; set; }
        public ICollection<showtime> showtime { get; set; }
        public hall hall { get; set; }
        [ForeignKey("hall")]
        public int hall_id { get; set; }




    }
}

