using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZorePazaryeriConverter
{
    [XmlRoot(ElementName = "Ozellik")]
    public class Ozellik
    {
        [XmlAttribute(AttributeName = "isim")]
        public string Isim { get; set; }
        [XmlText]
        public string Text { get; set; }
    }
}
