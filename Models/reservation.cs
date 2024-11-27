using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Models
{
    public class reservations
    {
        [Key]
        public int id { get; set; }


        public users users { get; set; }
        [ForeignKey("users")]
        public int user_id { get; set; }

        public DateTime reservedate { get; set; }
        public string reservedseat { get; set; }

        public showtime showtime { get; set; }
        [ForeignKey("showtime")]
        public int showtime_id { get; set; }


        public reservations(int user_id,DateTime reservedate,string reservedseat,int showtime_id)
        {
            this.user_id = user_id;
            this.reservedate = reservedate;
            this.reservedseat = reservedseat;
            this.showtime_id = showtime_id;
        }

        
       
    }
}
