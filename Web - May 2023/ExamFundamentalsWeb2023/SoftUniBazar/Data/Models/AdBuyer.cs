using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftUniBazar.Data.Models
{
    public class AdBuyer
    {
        [Required]
        [ForeignKey(nameof(Buyer))]
        public string BuyerId { get; set; } = null!;

        public IdentityUser Buyer { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Ad))]
        public int AdId { get; set; }

        public Ad Ad { get; set; } = null!;
    }

    /*•	BuyerId – a  string, Primary Key, foreign key (required)
•	Buyer – IdentityUser
•	AdId – an integer, Primary Key, foreign key (required)
•	Ad – Ad
*/
}
