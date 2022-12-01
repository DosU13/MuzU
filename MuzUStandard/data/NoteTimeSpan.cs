using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace MuzUStandard.data
{
    public class NoteTimeSpan : XmlBase
    {
        private string XElementName;

        public NoteTimeSpan() { }
        public NoteTimeSpan(string Name, XElement xElement) : base(xElement) => XElementName = Name;

        public long? MicroSeconds { get; set; }
        public long? Length_μs { get; set; }
        public long? Numerator { get; set; }
        public long? Denominator { get; set; }
        public long? LengthNumerator { get; set; }
        public long? LengthDenominator { get; set; }

        internal override XElement ToXElement()
        {
            var xElement = new XElement(XElementName);
            if (MicroSeconds != null) xElement.Add(new XAttribute(nameof(MicroSeconds), MicroSeconds));
            if (Length_μs != null) xElement.Add(new XAttribute(nameof(Length_μs), Length_μs));
            if (Numerator != null) xElement.Add(new XAttribute(nameof(Numerator), Numerator));
            if (Denominator != null) xElement.Add(new XAttribute(nameof(Denominator), Denominator));
            if (LengthNumerator != null) xElement.Add(new XAttribute(nameof(LengthNumerator), LengthNumerator));
            if (LengthDenominator != null) xElement.Add(new XAttribute(nameof(LengthDenominator), LengthDenominator));
            return xElement;
        }

        internal override XElement LoadFromXElement(XElement xElement)
        {
            var thisElement = xElement.Element(XElementName);
            MicroSeconds = long.TryParse(thisElement.Attribute(nameof(MicroSeconds))?.Value, out long tm) ? tm as long? : null;
            Length_μs = long.TryParse(thisElement.Attribute(nameof(Length_μs))?.Value, out long lm) ? lm as long? : null;
            Numerator = long.TryParse(thisElement.Attribute(nameof(Numerator))?.Value, out long tn) ? tn as long? : null;
            Denominator = long.TryParse(thisElement.Attribute(nameof(Denominator))?.Value, out long td) ? td as long? : null;
            LengthNumerator = long.TryParse(thisElement.Attribute(nameof(LengthNumerator))?.Value, out long ln) ? ln as long? : null;
            LengthDenominator = long.TryParse(thisElement.Attribute(nameof(LengthDenominator))?.Value, out long ld) ? ld as long? : null;
            return thisElement;
        }
    }
}
