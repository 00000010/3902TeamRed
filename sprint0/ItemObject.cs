using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;

namespace sprint0
{
    public class ItemObject
    {
        public string ObjectType { get; set; }
        public string ObjectName { get; set; }
        public string Location { get; set; }
        public int numX { get; set; }
        public int numY { get; set; }

        public ItemObject()
        {
            Location = "0 0";
            numX = 1;
            numY = 1;
        }

        public void parseData(IEnumerable<XElement> attributes)
        {
            foreach(XElement attribute in attributes)
            {
                string name = attribute.Name.ToString();
                string value = attribute.Value;
                this.GetType().GetProperty(name).SetValue(this, value);
            }
        }

    }
}

