using System.Collections.Generic;
using System.Xml.Linq;

namespace MuzUStandard.data
{
    internal class Node : XmlBase
    {
        public Node() { }
        internal Node(XElement xElement):base(xElement) { }

        internal double Time { get; set; } = 0;
        internal double? Length { get; set; }
        internal int? Note{ get; set; }
        internal string Lyrics { get; set; }

        internal override XElement ToXElement()
        {
            ThisElement = new XElement(GetType().Name,
                            new XElement(nameof(Time), Time));
            if (Length != null) ThisElement.Add(new XElement(nameof(Length), Length));
            if (Note != null) ThisElement.Add(new XElement(nameof(Note), Note));
            if (Lyrics != null) ThisElement.Add(new XElement(nameof(Lyrics), Lyrics));
            return base.ToXElement();
        }

        internal override void LoadFromXElement(XElement xElement)
        {
            ThisElement = xElement.Element(GetType().Name);
            Time = double.Parse(ThisElement.Element(nameof(Time)).Value);
            Length = double.TryParse(ThisElement.Element(nameof(Length))?.Value, out double _len) ? _len as double?: null;
            Note = int.TryParse(ThisElement.Element(nameof(Note))?.Value, out int _note) ? _note as int? : null;
            Lyrics = ThisElement.Element(nameof(Lyrics))?.Value;
            base.LoadFromXElement(ThisElement);
        }
    }
}
