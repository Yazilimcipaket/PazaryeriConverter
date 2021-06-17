using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZorePazaryeriConverter.XmlClasses
{
    [XmlRoot(ElementName = "Varyantlar")]
    public  class TekkartXmlClassVaryantlar
    {
        public TekkartXmlClassVaryantlar()
        {
            Varyantlar = new List<TekkartXmlClassVaryant>();
        }
        [XmlElement(ElementName = "varyant")]
        public List<TekkartXmlClassVaryant> Varyantlar { get; set; }
    }
}
