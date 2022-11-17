using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace MuzUStandard.data
{
    internal class Tempo : XmlBase
    {
        internal Tempo() { }
        internal Tempo(XElement xElement) : base(xElement) { }

        internal long MicrosecondsPerQuarterNote;
        internal TimeSignature TimeSignature; 

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

    internal class TimeSignature : XmlBase
    {
        internal TimeSignature() { }
        internal TimeSignature(XElement xElement) : base(xElement) { }

        internal long Numerator;
        internal long Denominator;

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
