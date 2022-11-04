using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace MuzUStandard.data
{
    public class Tempo : XmlBase
    {
        public Tempo() { }
        public Tempo(XElement xElement) : base(xElement) { }

        public long MicrosecondsPerQuarterNote;
        public TimeSignature TimeSignature; 

        internal override XElement ToXElement()
        {
            ThisElement = new XElement(GetType().Name,
                            new XElement(nameof(MicrosecondsPerQuarterNote), MicrosecondsPerQuarterNote),
                            TimeSignature.ToXElement());
            return base.ToXElement();
        }

        internal override void LoadFromXElement(XElement xElement)
        {
            base.LoadFromXElement(xElement);
            MicrosecondsPerQuarterNote = long.Parse(ThisElement.Element(nameof(MicrosecondsPerQuarterNote))?.Value ?? "0");
            TimeSignature = new TimeSignature(xElement);
        }
    }

    public class TimeSignature : XmlBase
    {
        public TimeSignature() { }
        public TimeSignature(XElement xElement) : base(xElement) { }

        public long Numerator;
        public long Denominator;

        internal override XElement ToXElement()
        {
            ThisElement = new XElement(GetType().Name,
                            new XElement(nameof(Numerator), Numerator),
                            new XElement(nameof(Denominator), Denominator));
            return base.ToXElement();
        }

        internal override void LoadFromXElement(XElement xElement)
        {
            base.LoadFromXElement(xElement);
            Numerator = long.Parse(ThisElement.Element(nameof(Numerator))?.Value ?? "0");
            Denominator = long.Parse(ThisElement.Element(nameof(Denominator))?.Value ?? "0");
        }
    }
}
