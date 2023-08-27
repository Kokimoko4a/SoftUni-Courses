using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ExportDto
{
    [XmlType("Creator")]
    public class CreatorExportDto
    {
        [XmlAttribute("BoardgamesCount")]
        public int BoardgamesCount { get; set; }

        [XmlElement("CreatorName")]
        public string CreatorName { get; set; } = null!;

        [XmlArray("Boardgames")]
        public List<BoardgameExportDtoLong> Boardgames { get; set; } = new List<BoardgameExportDtoLong>();
    }

    /*<Creators>
  <Creator BoardgamesCount="6">
    <CreatorName>Cade O'Neill</CreatorName>
    <Boardgames>
      <Boardgame>
        <BoardgameName>Bohnanza: The Duel</BoardgameName>
        <BoardgameYearPublished>2019</BoardgameYearPublished>
      </Boardgame>
*/
}
