using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Xml.Linq;

namespace sprint0
{
    public class Room
    {
        public List<object> roomObjects;
        public List<object> roomEnemies;
        public List<object> roomPlayers;
        public List<ItemObject> roomItemObjects;

        public string name { get; set; }

        public string WestRoom { get; set; }
        public string NorthRoom { get; set; }
        public string EastRoom { get; set; }
        public string SouthRoom { get; set; }

        public Room westRoomPtr { get; set; }
        public Room northRoomPtr { get; set; }
        public Room eastRoomPtr { get; set; }
        public Room southRoomPtr { get; set; }

        public Room()
        {
            roomObjects = new List<object>();
            roomEnemies = new List<object>();
            roomPlayers = new List<object>();
            roomItemObjects = new List<ItemObject>();
        }

        public void Add(object obj)
        {
            roomObjects.Add(obj);
            if (obj is Enemy)
            {
                roomEnemies.Add(obj);
            }
        }

        public void RemoveObject(object obj)
        {
            roomObjects.Remove(obj);
            if (obj is Enemy)
            {
                roomEnemies.Remove(obj);
            }
        }

        public void Add(ItemObject obj)
        {
            roomItemObjects.Add(obj);
        }

        public void AddPlayer(object player)
        {
            roomPlayers.Add(player);
        }

        //Loads all of the text corresponding to the pointers
        public void ParsePointers(IEnumerable<XElement> pointers)
        {
            foreach (XElement pointer in pointers)
            {
                //Tag element of XML
                string name = pointer.Name.ToString();
                //Data of each XML element
                string value = pointer.Value;
                //Sets the data into the right variable using the tag name
                this.GetType().GetProperty(name).SetValue(this, value);
            }
        }

        public override string ToString()
        {
            return ($"Name: {this.name}\n" +
                $"Westroom: {this.WestRoom}\n" +
                $"NorthRoom: {this.NorthRoom}\n" +
                $"EastRoom: {this.EastRoom}\n" +
                $"SouthRoom: {this.SouthRoom}");
        }
    }
}