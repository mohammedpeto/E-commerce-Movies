using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Models
{
    public class Actor
    {
        [Key]
        public int ID { get; set; }
        [Display(Name ="Profile Picture")]

        [Required(ErrorMessage ="The Profile Pic Is Requried")]
        public string ProfilePictureURL { get; set; }
        [Display(Name ="Full Name")]
        [Required]
        [StringLength(30,MinimumLength = 3,ErrorMessage ="The must be at least 3 char")]
        public string FullName { get; set; }
        [Display(Name = "Biography")]
        [Required]
        public string Bio { get; set; }
        public List<Actor_Movie> Actor_Movies { get; set; }


    }
}
