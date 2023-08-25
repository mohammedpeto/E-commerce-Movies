using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Models
{
    public class Producer
    {

        [Key]
        public int ID { get; set; }
        [Required]
        public string ProfilePictureURL { get; set; }
        [Required]
        [MinLength(3)]
        public string FullName { get; set; }
        [Required]
        public string Bio { get; set; }

        public List<Movie> Movies { get; set; }
    }
}
