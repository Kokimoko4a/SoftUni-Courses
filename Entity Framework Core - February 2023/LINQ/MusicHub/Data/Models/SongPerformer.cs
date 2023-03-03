using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicHub.Data.Models
{
    public class SongPerformer
    {
        [ForeignKey(nameof(Song))]
        public int 	SongId  { get; set; }

        [Required]
        public virtual Song Song { get; set; } = null!;

        [ForeignKey(nameof(Performer))]
        public int 	PerformerId  { get; set; }

        [Required]
        public virtual Performer Performer { get; set; } = null!;
    }
}
