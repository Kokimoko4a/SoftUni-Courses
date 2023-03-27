﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProductShop.DTOs.Export
{
     [XmlType("products")]
    public class ProductsCountAndInfo
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlElement("products")]
        public List<ProductExport> Products { get; set; } = new List<ProductExport>();
    }
}
