using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ExportDto
{
    [XmlType("Boardgame")]
    public class BoardgameExportDtoLong
    {
        [XmlElement("BoardgameName")]
        public string BoardgameName { get; set; } = null!;

        [XmlElement("BoardgameYearPublished")]
        public int BoardgameYearPublished { get; set; }
    }

    /*<Boardgame>
        <BoardgameName>Bohnanza: The Duel</BoardgameName>
        <BoardgameYearPublished>2019</BoardgameYearPublished>
      </Boardgame>*/
}
