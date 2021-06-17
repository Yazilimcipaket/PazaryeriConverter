using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZorePazaryeriConverter
{
    [XmlRoot(ElementName = "subproducts")]
    public class Subproducts
    {
        [XmlElement(ElementName = "subproduct")]
        public List<Subproduct>Subproduct { get; set; }
    }
}
