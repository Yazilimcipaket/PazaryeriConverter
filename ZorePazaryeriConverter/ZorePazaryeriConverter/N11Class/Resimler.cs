using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZorePazaryeriConverter
{
    [XmlRoot(ElementName = "Resimler")]
    public class Resimler
    {
        public Resimler()
        {
            Resim = new List<string>();
        }
        [XmlElement(ElementName = "Resim")]
        public List<string> Resim { get; set; }
    }
}
