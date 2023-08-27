using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boardgames.Data.Models
{
    public class Creator
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(7, MinimumLength = 2)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(7,MinimumLength = 2)]
        public string LastName { get; set; } = null!;

        //May be required
        public virtual ICollection<Boardgame> Boardgames { get; set; } = new HashSet<Boardgame>();
    }

    /*•	Id – integer, Primary Key
•	FirstName – text with length [2, 7] (required) 
•	LastName – text with length [2, 7] (required)
•	Boardgames – collection of type Boardgame
*/
}
