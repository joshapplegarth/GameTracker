using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameTracker.Models
{
    [Table("Location")]
    public class Location
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter the city")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please enter the state")]
        public string State { get; set; }
        [Required(ErrorMessage = "Please enter the land owner")]
        public string LandOwner { get; set; }
        public IEnumerable<Game> Game { get; set; }
        public int UserId { get; set; }



    }
}
