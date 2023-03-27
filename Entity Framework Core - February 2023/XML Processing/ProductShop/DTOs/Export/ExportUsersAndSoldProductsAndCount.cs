using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProductShop.DTOs.Export
{
    [XmlType("Users")]
    public class ExportUsersAndSoldProductsAndCount
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlElement("users")]
        public List<UserAndSoldProductsExport> UsersAndProducts { get; set; } = new List<UserAndSoldProductsExport>();
    }
}
