using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Trucks.Data.Models;

namespace Trucks.DataProcessor.ImportDto
{
	[XmlType("Despatcher")]
    public class DespatchersImportDto
    {
		[Required]
		[StringLength(40,MinimumLength = 2)]
		[XmlElement("Name")]
		public string? Name { get; set; }

		[XmlElement("Position")]
		[Required]
		public string? Position { get; set; }

		[XmlArray("Trucks")]
		public HashSet<TruckDtoImport> Trucks { get; set; } = new HashSet<TruckDtoImport>();
	}

    /*<Name>Genadi Petrov</Name>
		<Position>Specialist</Position>
		<Trucks>
			<Truck>
				<RegistrationNumber>CB0796TP</RegistrationNumber>
				<VinNumber>YS2R4X211D5318181</VinNumber>
				<TankCapacity>1000</TankCapacity>
				<CargoCapacity>23999</CargoCapacity>
				<CategoryType>0</CategoryType>
				<MakeType>3</MakeType>
			</Truck>*/
}
