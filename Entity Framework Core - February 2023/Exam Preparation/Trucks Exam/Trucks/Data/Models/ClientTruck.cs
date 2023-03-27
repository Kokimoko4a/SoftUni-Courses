using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trucks.Data.Models
{
    public class ClientTruck
    {
        [ForeignKey(nameof(Client))]
        [Required]
        public int ClientId { get; set; }

        //May be nullable
        public virtual Client Client { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Truck))]
        public int TruckId { get; set; }

        //May be nullable
        public virtual Truck Truck { get; set; } = null!;
    }

    /*•	ClientId – integer, Primary Key, foreign key (required)
•	Client – Client
•	TruckId – integer, Primary Key, foreign key (required)
•	Truck – Truck
*/
}
