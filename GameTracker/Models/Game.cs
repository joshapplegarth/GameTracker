using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GameTracker.Models
{
    [Table("Game")]
    public class Game
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the game Type")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Please enter the Gender")]
        public string Gender { get; set; }

        [Column(TypeName = "decimal(7, 1)")]
        [UIHint("number")]
        public int? Weight { get; set; }

        [Required(ErrorMessage = "Please enter the Date")]
        [DataType(DataType.Date)]
        [UIHint("date")]
        public string Date { get; set; }
        //[ForeignKey(nameof(Location.Id))]
        //[HiddenInput(DisplayValue = false)]
        public int LocationId { get; set; }

        public Location Location { get; set; }

    }
}
