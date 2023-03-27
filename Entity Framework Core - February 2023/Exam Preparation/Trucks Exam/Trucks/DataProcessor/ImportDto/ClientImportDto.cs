using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Trucks.DataProcessor.ImportDto
{
    public class ClientImportDto
    {
        [JsonProperty("Name")]
        [StringLength(40, MinimumLength = 3)]
        [Required]
        
        public string? Name { get; set; }

        [JsonProperty("Nationality")]
        [StringLength(40,MinimumLength = 2)]
        [Required]
        public string? Nationality { get; set; }

        [JsonProperty("Type")]
        [Required]
        public string? Type { get; set; }

        [JsonProperty("Trucks")]
        
        public List<int> Trucks { get; set; } = new List<int>();
    }


    /*{
    "Name": "Kuenehne + Nagel (AG & Co.) KGKuenehne + Nagel (AG & Co.) KGKuenehne + Nagel (AG & Co.) KG",
    "Nationality": "The Netherlands",
    "Type": "golden",
    "Trucks": [
      1,
      68,
      73,
      17,
      98,
      98
    ]
  },*/
}
