﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace MuzUStandard.data
{
    public class MusicalTimeSpan : XmlBase
    {
        private string XElementName;

        public MusicalTimeSpan(string Name) => XElementName = Name;
        public MusicalTimeSpan(string Name, XElement xElement)
        {
            XElementName = Name;
            LoadFromXElement(xElement);
        }

        public long? MicroSeconds { get; set; }
        public long? Numerator { get; set; }
        public long? Denominator { get; set; }

        internal override XElement ToXElement()
        {
            var xElement = new XElement(XElementName);
            if (MicroSeconds != null) xElement.Add(new XAttribute(nameof(MicroSeconds), MicroSeconds));
            if (Numerator != null) xElement.Add(new XAttribute(nameof(Numerator), Numerator));
            if (Denominator != null) xElement.Add(new XAttribute(nameof(Denominator), Denominator));
            return xElement;
        }

        internal override XElement LoadFromXElement(XElement xElement)
        {
            var thisElement = xElement.Element(XElementName);
            MicroSeconds = long.TryParse(thisElement.Attribute(nameof(MicroSeconds))?.Value, out long tm) ? tm as long? : null;
            Numerator = long.TryParse(thisElement.Attribute(nameof(Numerator))?.Value, out long tn) ? tn as long? : null;
            Denominator = long.TryParse(thisElement.Attribute(nameof(Denominator))?.Value, out long td) ? td as long? : null;
            return thisElement;
        }
    }
}
