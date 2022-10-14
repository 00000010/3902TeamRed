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
        public string Dimension { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }
        public int NumX { get; set; }
        public int NumY { get; set; }

        public ItemObject()
        {
            Dimension = "1 1";
            Location = "0 0";
        }

        public void parseData(IEnumerable<XElement> attributes)
        {
            foreach(XElement attribute in attributes)
            {
                //Tag element of XML
                string name = attribute.Name.ToString();
                //Data of each XML element
                string value = attribute.Value;
                //Sets the data into the right variable using the tag name
                this.GetType().GetProperty(name).SetValue(this, value);
            }
            string[] splitLocation = this.Location.Split(' ');
            PosX = Int32.Parse(splitLocation[0]);
            PosY = Int32.Parse(splitLocation[1]);

            string[] splitDimension = this.Dimension.Split(' ');
            NumX = Int32.Parse(splitDimension[0]);
            NumY = Int32.Parse(splitDimension[1]);
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

