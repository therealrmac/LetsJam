using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LetsJam.Models
{
    public class Band
    {
        [Key]
        public int BandId { get; set; }

        [Required]
        public string bandName { get; set; }

        [Required]
        public ApplicationUser user { get; set; }

        public string BandImage { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime created { get; set; }
    }
}
