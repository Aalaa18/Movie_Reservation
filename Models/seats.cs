using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Models
{
    public class seats
    {
        [Key]
        public int Id { get; set; }
        public ICollection<showtimeseats>showtimeseats { get; set; }
       
    }
}
