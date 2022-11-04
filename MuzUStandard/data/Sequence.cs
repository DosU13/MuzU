using System.Xml.Linq;

namespace MuzUStandard.data
{
    public class Sequence : XmlBase
    {
        public Sequence(){}
        public Sequence(XElement xElement) : base(xElement) { }

        public string Name;
        public SequenceTemplate SequenceTemplate { get; set; } = new SequenceTemplate();
        public NodeList NodeList { get; set; } = new NodeList();

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
