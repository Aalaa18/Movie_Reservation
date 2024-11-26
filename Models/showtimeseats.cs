using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Models
{
    public  class showtimeseats
    {
        [Key] 
        public int id { get; set; }

        public seats seats { get; set; }
        
        public showtime showtime { get; set; }

        public bool istaken { get; set; }

        [ForeignKey("seats")]
        public int seat_id;

        [ForeignKey("showtime")]
        public int showtime_id { get; set; }

    

        
    }
}
