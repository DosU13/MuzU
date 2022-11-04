using System.Xml.Linq;

namespace MuzUStandard.data
{
    public class NodeList : XmlList<Node>
    {
        public NodeList() { }
        public NodeList(XElement xElement) : base(xElement) { }

        internal override XElement ToXElement()
        {
            ThisElement = new XElement(GetType().Name);
            return base.ToXElement();
        }

        internal override void LoadFromXElement(XElement xElement)
        {
            ThisElement = xElement.Element(GetType().Name);
            base.LoadFromXElement(ThisElement);
        }
    }
}
