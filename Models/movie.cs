using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Models
{
    public class movie
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string category { get; set; }
        public ICollection<servedhall> hall { get; set; }


        public movie(string Name,string Description,string category) { 
        
            this.Name = Name;
            this.Description = Description;
            this.category = category;
        }

    }
}
