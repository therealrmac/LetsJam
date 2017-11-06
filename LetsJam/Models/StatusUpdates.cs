using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LetsJam.Models
{
    public class StatusUpdates
    {
        [Key]
        public int updateId { get; set; }
        
        [Display(Name ="Message")]
        public string message { get; set; }

        [Required]
        public ApplicationUser user { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime created { get; set; }
    }
}
