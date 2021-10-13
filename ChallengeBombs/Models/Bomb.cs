using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChallengeBombs.Models
{
    public class Bomb
    {
        public int ID { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }
        [Range(1,2000)]
        [Required]
        public int Time { get; set; }
        [Range(1, 1000)]
        [Required]
        public int Modules { get; set; }
        [Required]
        [StringLength(30)]
        public string Difficulty { get; set; }
        [StringLength(100)]
        public string Pack { get; set; }
        [StringLength(100)]
        [Display(Name = "Hardest Modules")]
        public string Hardest { get; set; }

    }
}
