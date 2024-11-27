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

        public users(string Name,string pass,string email,string type ) { 
          
            this.Name = Name;
            this.pass = pass;
            this.email = email;
            this.type = type;
        
        }
    }
}
