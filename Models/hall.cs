using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Models
{
    public class hall
    {
        [Key]
        public int id { get; set; }

        public ICollection<servedhall> servedhalls { get; set; }
    }
}
