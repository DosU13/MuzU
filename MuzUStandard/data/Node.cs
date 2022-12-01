using System.Collections.Generic;
using System.Xml.Linq;

namespace MuzUStandard.data
{
    public class Node : XmlBase
    {
        public Node() { }
        internal Node(XElement xElement):base(xElement) { }

        public NoteTimeSpan Time { get; set; }
        public NoteTimeSpan Length { get; set; }
        public int? Note{ get; set; }
        public string Lyrics { get; set; }

        internal override XElement ToXElement()
        {
            var xElement = base.ToXElement();
            xElement.Add(Time.ToXElement());
            if (Length != null) xElement.Add(Length.ToXElement());
            if (Note != null) xElement.Add(new XElement(nameof(Note), Note));
            if (Lyrics != null) xElement.Add(new XElement(nameof(Lyrics), Lyrics));
            return xElement;
        }

        internal override XElement LoadFromXElement(XElement xElement)
        {
            var thisElement = base.LoadFromXElement(xElement);
            Time = new NoteTimeSpan(nameof(Time), thisElement);
            Length = new NoteTimeSpan(nameof(Length), thisElement);
            Note = int.TryParse(thisElement.Element(nameof(Note))?.Value, out int _note) ? _note as int? : null;
            Lyrics = thisElement.Element(nameof(Lyrics))?.Value;
            return thisElement;
        }
    }
}
