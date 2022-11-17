using System.Xml.Linq;

namespace MuzUStandard.data
{
    internal class SequenceList : XmlList<Sequence>
    {
        internal SequenceList() { }
        internal SequenceList(XElement xElement) : base(xElement) { }

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
