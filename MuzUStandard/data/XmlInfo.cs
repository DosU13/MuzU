using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace MuzUStandard.data
{
    public abstract class XmlInfo: XmlBase
    {
        internal XmlInfo() { Infos = new Dictionary<string, string>(); }

        internal XmlInfo(Dictionary<string, string> infos) { Infos = infos;}

        internal XmlInfo(XElement xElement) : base(xElement) { }

        public readonly Dictionary<string, string> Infos;
        
        internal override XElement ToXElement()
        {
            ThisElement.Add(Infos.Select(x => new XElement(x.Key, x.Value)));
            return base.ToXElement();
        }

        internal override void LoadFromXElement(XElement xElement)
        {
            base.LoadFromXElement(xElement);
            foreach (var x in xElement.Elements()) { Infos.Add(x.Name.LocalName, x.Value); }
        }
    }
}
