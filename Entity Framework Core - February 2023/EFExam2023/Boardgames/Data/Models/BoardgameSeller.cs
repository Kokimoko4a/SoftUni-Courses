using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boardgames.Data.Models
{
    public class BoardgameSeller
    {
        [Required]
        [ForeignKey(nameof(Boardgame))]
        public int BoardgameId { get; set; }

        //May be not required
        [Required]
        public virtual Boardgame Boardgame { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Seller))]
        public int SellerId { get; set; }

        //May be not required
        [Required]
        public virtual Seller Seller { get; set; } = null!;
    }

    /*•	BoardgameId – integer, Primary Key, foreign key (required)
•	Boardgame – Boardgame
•	SellerId – integer, Primary Key, foreign key (required)
•	Seller – Seller
*/
}
