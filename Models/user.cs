using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Models
{
    public class users
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string pass { get; set; }
        public string email { get; set; }
        public string type { get; set; }

        public ICollection<reservations> reservations { get; set; }
    }
}
