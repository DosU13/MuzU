using System.Collections.Generic;
using System.Reflection;
using System.Xml.Linq;

namespace MuzUStandard.data
{
    public class MuzUData: XmlBase
    {
        public MuzUData() { }
        public MuzUData(XElement xElement) : base(xElement) { }

        public Identity Identity;
        public Music Music;
        public MusicLocal MusicLocal;
        public Tempo Tempo;
        public SequenceList SequenceList;

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

    public class Identity : XmlInfo
    {
        public Identity() : base() { }
        public Identity(XElement xElement) : base(xElement) { }

        public string Name { get => Infos[nameof(Name)]; set => Infos[nameof(Name)] = value; }
        public string Creator { get => Infos[nameof(Creator)]; set => Infos[nameof(Creator)] = value; }
        public string CommentFromCreator { get => Infos[nameof(CommentFromCreator)]; set => Infos[nameof(CommentFromCreator)] = value; }
    }

    public class Music : XmlInfo
    {
        public Music() : base() { }
        public Music(XElement xElement) : base(xElement) { }

        public string Name { get => Infos[nameof(Name)]; set => Infos[nameof(Name)] = value; }
        public string Author { get => Infos[nameof(Author)]; set => Infos[nameof(Author)] = value; }
        public string MusicVersion { get => Infos[nameof(MusicVersion)]; set => Infos[nameof(MusicVersion)] = value; }
    }

    public class MusicLocal : XmlBase
    {
        public MusicLocal() { }
        public MusicLocal(XElement xElement): base(xElement) {}

        public string MusicPath;
        public long MusicOffsetMicroseconds; // if positive audio has excess part, vice versa
        
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
