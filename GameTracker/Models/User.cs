using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameTracker.Models
{
    [Table("User")]
    public class User
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        [Required(ErrorMessage = "Please enter your Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter your Password")]
        public string Password { get; set; }
        public bool? IsAdmin { get; set; }


    }
}
