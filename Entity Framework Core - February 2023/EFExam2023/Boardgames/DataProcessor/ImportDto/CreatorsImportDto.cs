using Boardgames.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ImportDto
{
	[XmlType("Creator")]
    public class CreatorsImportDto
    {
		[XmlElement("FirstName")]
		[Required]
		[StringLength(7,MinimumLength = 2)]
		public string FirstName { get; set; } = null!;

		[XmlElement("LastName")]
        [Required]
        [StringLength(7, MinimumLength = 2)]
        public string LastName { get; set; } = null!;

		[XmlArray("Boardgames")]
		public List<BoardgameImportDto> Boardgames { get; set; } = new List<BoardgameImportDto>();


	}

    /*<Creators>
	<Creator>
		<FirstName>Debra</FirstName>
		<LastName>Edwards</LastName>
		<Boardgames>
			<Boardgame>
				<Name>4 Gods</Name>
				<Rating>7.28</Rating>
				<YearPublished>2017</YearPublished>
				<CategoryType>4</CategoryType>
				<Mechanics>Area Majority / Influence, Hand Management, Set Collection, Simultaneous Action Selection, Worker Placement</Mechanics>*/
}
