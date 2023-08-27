using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boardgames.DataProcessor.ImportDto
{
    public class SellerImportDto
    {
        [JsonProperty("Name")]
        [Required]
        [StringLength(20,MinimumLength = 5)]
        public string Name { get; set; } = null!;

        [JsonProperty("Address")]
        [Required]
        [StringLength(30,MinimumLength = 2)]
        public string Address { get; set; } = null!;

        [JsonProperty("Country")]
        [Required]
        public string Country { get; set; } = null!;

        [JsonProperty("Website")]
        [Required]
        [RegularExpression("^www\\.[A-Za-z-]+\\.com$")]
        public string Website { get; set; } = null!;

        [JsonProperty("Boardgames")]
        public List<int> Boardgames { get; set; } = new List<int>();
    }

    /*"Name": "6am",
    "Address": "The Netherlands",
    "Country": "Belgium",
	  "Website": "www.6pm.com",
    "Boardgames": [
			1,
			105,
			1,
			5,
			15
*/
}
