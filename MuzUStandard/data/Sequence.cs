using System.Xml.Linq;

namespace MuzUStandard.data
{
    internal class Sequence : XmlBase
    {
        public Sequence(){}
        internal Sequence(XElement xElement) : base(xElement) { }

        internal string Name;
        internal SequenceTemplate SequenceTemplate { get; set; } = new SequenceTemplate();
        internal NodeList NodeList { get; set; } = new NodeList();

        internal override XElement ToXElement()
        {
            ThisElement = new XElement(nameof(Sequence),
                            new XElement(nameof(Name), Name),
                            SequenceTemplate.ToXElement(),
                            NodeList.ToXElement());
            return base.ToXElement();
        }

        internal override void LoadFromXElement(XElement xElement)
        {
            ThisElement = xElement.Element(nameof(Sequence));
            Name = ThisElement.Element(nameof(Name)).Value;
            SequenceTemplate = new SequenceTemplate(ThisElement);
            NodeList = new NodeList(ThisElement);
            base.LoadFromXElement(ThisElement);
        }
    }
}
