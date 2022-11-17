using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace MuzUStandard.data
{
    internal enum TimeUnite { Microsecond, WholeNote, QuarterNote}

    static class Extensions
    {
        internal static TimeUnite ParseToTimeUnit(string str)
        {
            if (str == TimeUnite.Microsecond.ToString()) return TimeUnite.Microsecond;
            else if (str == TimeUnite.WholeNote.ToString()) return TimeUnite.WholeNote;
            else return TimeUnite.QuarterNote;
        }
    }

    internal class SequenceTemplate : XmlBase
    {
        internal SequenceTemplate() { }
        internal SequenceTemplate(XElement xElement) : base(xElement) { }

        internal bool LengthEnabled { get; set; } = false;
        internal bool NoteEnabled { get; set; } = false;
        internal bool LyricsEnabled { get; set; } = false;
        internal TimeUnite TimeUnit { get; set; } = TimeUnite.QuarterNote;
        internal PropertiesList PropertiesList { get; set; } = new PropertiesList();

        internal override XElement ToXElement()
        {
            ThisElement = new XElement(GetType().Name,
                            new XElement(nameof(LengthEnabled), LengthEnabled),
                            new XElement(nameof(NoteEnabled), NoteEnabled),
                            new XElement(nameof(LyricsEnabled), LyricsEnabled),
                            new XElement(nameof(TimeUnit), TimeUnit.ToString()),
                            PropertiesList.ToXElement());
            return base.ToXElement();
        }

        internal override void LoadFromXElement(XElement xElement)
        {
            ThisElement = xElement.Element(GetType().Name);
            LengthEnabled = bool.Parse(ThisElement.Element(nameof(LengthEnabled)).Value);
            NoteEnabled = bool.Parse(ThisElement.Element(nameof(NoteEnabled)).Value);
            LyricsEnabled = bool.Parse(ThisElement.Element(nameof(LyricsEnabled)).Value);
            TimeUnit = Extensions.ParseToTimeUnit(ThisElement.Element(nameof(TimeUnit)).Value);
            PropertiesList = new PropertiesList(ThisElement);
            base.LoadFromXElement(ThisElement);
        }
    }

    internal class PropertiesList : XmlList<Property>
    {
        internal PropertiesList() { }
        internal PropertiesList(XElement xElement) : base(xElement) { }

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

    internal class Property : XmlBase
    {
        public Property() { }
        internal Property(string name) 
        {
            Name = name;
        }

        internal Property(XElement xElement) : base(xElement) { }

        internal string Name { get; set; } = "NoName";

        internal override XElement ToXElement()
        {
            ThisElement = new XElement(GetType().Name,
                            new XElement(nameof(Name), Name));
            return base.ToXElement();
        }

        internal override void LoadFromXElement(XElement xElement)
        {
            ThisElement = xElement.Element(GetType().Name);
            Name = ThisElement.Element(nameof(Name)).Value;
            base.LoadFromXElement(ThisElement);
        }
    }

    //internal static class Extensions
    //{
    //    internal static string _ToString(this ValueType type)
    //    {
    //        if (type == ValueType.Integer) return "Integer";
    //        else if (type == ValueType.Decimal) return "Decimal";
    //        else return "NoWay this is impossible";
    //    }

    //    internal static ValueType ParseToValueType(this String type)
    //    {
    //        if (type == "Integer") return ValueType.Integer;
    //        else return ValueType.Decimal;
    //    }
    //}

    //internal enum ValueType { Integer, Decimal } //TinyText}
}
