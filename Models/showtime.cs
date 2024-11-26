using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Models
{
    public class showtime
    {
        [Key] 
        public int id { get; set; }
        public DateTime date { get; set; }

        public servedhall servedhall { get; set; }
        [ForeignKey("servedhall")]
        public int show_hall_id { get; set; }

        public bool is_active { get; set; }

        public ICollection<showtimeseats> showtimeseats { get; set; }

        public ICollection<reservations> reservations { get; set; }
    }
}
