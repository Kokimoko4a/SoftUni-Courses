using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boardgames.DataProcessor.ExportDto
{
    public class BoardgameExportDto
    {
        [JsonProperty("Name")]
        public string Name { get; set; } = null!;

        [JsonProperty("Rating")]
        public double Rating { get; set; }

        [JsonProperty("Mechanics")]
        public string Mechanics { get; set; } = null!;

        [JsonProperty("Category")]
        public string Category { get; set; } = null!;


    }

    /*"Name": "The Fog of War",
        "Rating": 9.65,
        "Mechanics": "Grid Movement, Hand Management, Rock-Paper-Scissors, Time Track, Variable Player Powers",
        "Category": "Strategy"*/
}
