using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boardgames.DataProcessor.ExportDto
{
    public class SellerExportDto
    {
        [JsonProperty("Name")]
        public string Name { get; set; } = null!;

        [JsonProperty("Website")]
        public string Website { get; set; } = null!;

        [JsonProperty("Boardgames")]
        public List<BoardgameExportDto> Boardgames { get; set; } = new List<BoardgameExportDto>();
    }

    /*"Name": "Bedsure",
    "Website": "www.bedsure.com",
    "Boardgames": [
      {
        "Name": "The Fog of War",
        "Rating": 9.65,
        "Mechanics": "Grid Movement, Hand Management, Rock-Paper-Scissors, Time Track, Variable Player Powers",
        "Category": "Strategy"
      },
*/
}
