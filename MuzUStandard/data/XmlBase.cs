using System.Xml.Linq;

namespace MuzUStandard.data
{
    internal abstract class XmlBase
    {
        protected XElement ThisElement = new XElement("empty_xmlbase");

        internal XmlBase() { }
        internal XmlBase(XElement xElement) { LoadFromXElement(xElement); }

        internal virtual XElement ToXElement() { return ThisElement; }
        internal virtual void LoadFromXElement(XElement xElement) { }
    }
}
