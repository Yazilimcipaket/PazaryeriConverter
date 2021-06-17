using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZorePazaryeriConverter
{
    [XmlRoot(ElementName = "images")]
    public class Images
    {
        [XmlElement(ElementName = "img_item")]
        public List<string> Img_item { get; set; }
    }
}
