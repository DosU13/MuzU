using MuzUStandard.data;
using System.IO;
using System.Xml.Linq;

namespace MuzUStandard
{
    public class MuzUProject
    {
        internal string Name { get; set; }
        internal MuzUData data;

        public MuzUProject() => data = new MuzUData();

        public MuzUProject(Stream stream) => data = LoadFromStream(stream);

        private MuzUData LoadFromStream(Stream stream) 
        {
            return new MuzUData(XDocument.Load(stream).Root);
        }

        public void Save(Stream stream)
        { 
            stream.SetLength(0);
            ToXDocument().Save(stream);
        }

        private XDocument ToXDocument()
        {
            XDocument doc = new XDocument(data.ToXElement());
            doc.Declaration = new XDeclaration("1.0", "utf-8", "true");
            return doc;
        }
    }
}
