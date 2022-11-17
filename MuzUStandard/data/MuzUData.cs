using System.Collections.Generic;
using System.Reflection;
using System.Xml.Linq;

namespace MuzUStandard.data
{
    internal class MuzUData: XmlBase
    {
        internal MuzUData() { }
        internal MuzUData(XElement xElement) : base(xElement) { }

        internal Identity Identity;
        internal Music Music;
        internal MusicLocal MusicLocal;
        internal Tempo Tempo;
        internal SequenceList SequenceList;

        internal override XElement ToXElement()
        {
            ThisElement = new XElement(GetType().Name,
                            Identity.ToXElement(),
                            Music.ToXElement(),
                            MusicLocal.ToXElement(),
                            Tempo.ToXElement(),
                            SequenceList.ToXElement());
            return ThisElement;
        }

        internal override void LoadFromXElement(XElement xElement)
        {
            ThisElement = xElement;
            Identity = new Identity(xElement);
            Music = new Music(xElement);
            MusicLocal = new MusicLocal(xElement);
            Tempo = new Tempo(xElement);
            SequenceList = new SequenceList(xElement);
            base.LoadFromXElement(ThisElement);
        }
    }

    internal class Identity : XmlInfo
    {
        internal Identity() : base() { }
        internal Identity(XElement xElement) : base(xElement) { }

        internal string Name { get => Infos[nameof(Name)]; set => Infos[nameof(Name)] = value; }
        internal string Creator { get => Infos[nameof(Creator)]; set => Infos[nameof(Creator)] = value; }
        internal string CommentFromCreator { get => Infos[nameof(CommentFromCreator)]; set => Infos[nameof(CommentFromCreator)] = value; }
    }

    internal class Music : XmlInfo
    {
        internal Music() : base() { }
        internal Music(XElement xElement) : base(xElement) { }

        internal string Name { get => Infos[nameof(Name)]; set => Infos[nameof(Name)] = value; }
        internal string Author { get => Infos[nameof(Author)]; set => Infos[nameof(Author)] = value; }
        internal string MusicVersion { get => Infos[nameof(MusicVersion)]; set => Infos[nameof(MusicVersion)] = value; }
    }

    internal class MusicLocal : XmlBase
    {
        internal MusicLocal() { }
        internal MusicLocal(XElement xElement): base(xElement) {}

        internal string MusicPath;
        internal long MusicOffsetMicroseconds; // if positive audio has excess part
        
        internal override XElement ToXElement()
        {
            ThisElement = new XElement(GetType().Name,
                            new XElement(nameof(MusicPath), MusicPath),
                            new XElement(nameof(MusicOffsetMicroseconds), MusicOffsetMicroseconds));
            return base.ToXElement();
        }

        internal override void LoadFromXElement(XElement xElement)
        {
            base.LoadFromXElement(xElement);
            MusicPath = ThisElement.Element(nameof(MusicPath)).Value;
            MusicOffsetMicroseconds = long.Parse(ThisElement.Element(nameof(MusicOffsetMicroseconds))?.Value ?? "0");
        }
    }
}
