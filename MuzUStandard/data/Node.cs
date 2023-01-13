using System.Collections.Generic;
using System.Xml.Linq;

namespace MuzUStandard.data
{
    public class Node : XmlBase
    {
        public Node() { }
        internal Node(XElement xElement):base(xElement) { }

        public MusicalTimeSpan Time { get; set; } = new MusicalTimeSpan(nameof(Time));
        public MusicalTimeSpan Length { get; set; }
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
            Time = new MusicalTimeSpan(nameof(Time), thisElement);
            if(thisElement.Element(nameof(Length))!=null) 
                Length = new MusicalTimeSpan(nameof(Length), thisElement);
            Note = int.TryParse(thisElement.Element(nameof(Note))?.Value, out int _note) ? _note as int? : null;
            Lyrics = thisElement.Element(nameof(Lyrics))?.Value;
            return thisElement;
        }
    }
}
