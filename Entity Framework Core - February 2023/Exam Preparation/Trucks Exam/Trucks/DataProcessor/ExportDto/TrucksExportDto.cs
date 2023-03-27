using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Trucks.Data.Models.Enums;

namespace Trucks.DataProcessor.ExportDto
{
    public class TrucksExportDto
    {
        [JsonProperty("TruckRegistrationNumber")]
        public string TruckRegistrationNumber { get; set; } = null!;

        [JsonProperty("VinNumber")]
        public string VinNumber { get; set; } = null!;

        [JsonProperty("TankCapacity")]
        public int TankCapacity { get; set; }

        [JsonProperty("CargoCapacity")]
        public int CargoCapacity { get; set; }

        [JsonProperty("CategoryType")]
        public string CategoryType { get; set; } 

        [JsonProperty("MakeType")]
        public string MakeType { get; set; } 
    }
}
