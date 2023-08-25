using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Models
{
    public class Cinema
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Logo { get; set; }
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Movie> Movies { get; set; }


    }
}
