using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trucks.DataProcessor.ExportDto
{
    internal class ClientDtoExport
    {
        [JsonProperty("Name")]
        public string Name { get; set; } = null!;

        [JsonProperty("Trucks")]
        public List<TrucksExportDto> Trucks { get; set; } = new List<TrucksExportDto>();
    }
}
