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
        public int NumX { get; set; }
        public int NumY { get; set; }

        public ItemObject()
        {
            Location = "0 0";
            NumX = 1;
            NumY = 1;
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

        public override string ToString()
        {
            return ($"Type: {this.ObjectType}\n" +
                    $"Name: {this.ObjectName}\n" +
                    $"Location: {this.Location}\n" +
                    $"NumX: {this.NumX}\n" +
                    $"NumY: {this.NumY}\n");
        }

    }
}

