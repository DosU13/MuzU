using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace MuzUStandard.data
{
    public abstract class XmlList<T> : XmlBase where T : XmlBase, new()
    {
        internal XmlList() {}
        
        internal XmlList(XElement xElement) : base(xElement) { }

        List<T> List;

        internal override XElement ToXElement()
        {
            ThisElement.Add(new XAttribute("count", List.Count));
            for (int i = 0; i < List.Count; i++)
            {
                ThisElement.Add(new XElement("item-" + i, List[i]?.ToXElement()));
            }
            return base.ToXElement();
        }

        internal override void LoadFromXElement(XElement xElement)
        {
            base.LoadFromXElement(xElement);
            
            int count = int.Parse(ThisElement.Attribute("count").Value);
            List = new List<T>(count);
            for (int i = 0; i < count; i++)
            {
                XElement item = ThisElement.Element("item-" + i);
                T t = new T();
                t.LoadFromXElement(item);
                List.Insert(i, t);
            }
        }
    }
}
