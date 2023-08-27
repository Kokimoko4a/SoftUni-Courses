using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ImportDto
{
    [XmlType("Boardgame")]
    public class BoardgameImportDto
    {
        [XmlElement("Name")]
        [Required]
        [StringLength(20, MinimumLength = 10)]
        public string Name { get; set; } = null!;

        [XmlElement("Rating")]
        [Required]
        [Range(1, 10.00)]
        public double Rating { get; set; }

        [XmlElement("YearPublished")]
        [Required]
        [Range(2018, 2023)]
        public int YearPublished { get; set; } 

        [XmlElement("CategoryType")]
        [Required]
        public int CategoryType { get; set; }

        [XmlElement("Mechanics")]
        [Required]
        public string Mechanics { get; set; } = null!;
    }

    /*<Boardgame>
				<Name>4 Gods</Name>
				<Rating>7.28</Rating>
				<YearPublished>2017</YearPublished>
				<CategoryType>4</CategoryType>
				<Mechanics>Area Majority / Influence, Hand Management, Set Collection, Simultaneous Action Selection, Worker Placement</Mechanics>*/
}
