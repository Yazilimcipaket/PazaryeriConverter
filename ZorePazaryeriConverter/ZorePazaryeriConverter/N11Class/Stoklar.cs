using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZorePazaryeriConverter
{
    [XmlRoot(ElementName = "Stoklar")]
    public class Stoklar
    {
        public Stoklar()
        {
            Stok = new List<Stok>();
        }
        [XmlElement(ElementName = "Stok")]
        public List<Stok> Stok { get; set; }
    }
}
