using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using Microsoft.Xna.Framework;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace sprint0
{
    public class Room
    {
        public List<object> roomObjects;
        public List<object> roomEnemies;
        public List<object> roomPlayers;
        public List<ItemObject> roomItemObjects;

        public string name { get; set; }
        public bool start { get; set; }

        public string WestRoom { get; set; }
        public string NorthRoom { get; set; }
        public string EastRoom { get; set; }
        public string SouthRoom { get; set; }

        public Room westRoomPtr { get; set; }
        public Room northRoomPtr { get; set; }
        public Room eastRoomPtr { get; set; }
        public Room southRoomPtr { get; set; }

        //Used for level creation
        public Vector2 coordinate { get; set; }
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

        public bool existsInLocation(Vector2 location)
        {
            bool existsInLocation = false;

            foreach (object obj in roomObjects)
            {
                if (obj is Block)
                {
                    IBlock tempBlock = (IBlock)obj;
                    if (tempBlock.Position == location)
                    {
                        existsInLocation = true;
                    }
                }
                else if (obj is Enemy)
                {
                    IEnemy tempEnemy = (IEnemy)obj;
                    if (tempEnemy.Position == location)
                    {
                        existsInLocation = true;
                    }
                }
                else if (obj is Door)
                {
                    IDoor tempDoor = (IDoor)obj;
                    if (tempDoor.Position == location)
                    {
                        existsInLocation = true;
                    }
                }
                else if (obj is Item)
                {
                    IItem tempItem = (IItem)obj;
                    if (tempItem.Position == location)
                    {
                        existsInLocation = true;
                    }
                }
            }

            return existsInLocation;
        }

        public object getFromLocation(Vector2 location)
        {
            object objectWithSameLocation = null;

            foreach (object obj in roomObjects)
            {
                if (obj is Block)
                {
                    IBlock tempBlock = (IBlock)obj;
                    if (tempBlock.Position == location)
                    {
                        Debug.WriteLine("Same Block!");
                        objectWithSameLocation = obj;
                    }
                }
                else if (obj is Enemy)
                {
                    IEnemy tempEnemy = (IEnemy)obj;
                    if (tempEnemy.Position == location)
                    {
                        objectWithSameLocation = obj;
                    }
                }
                else if (obj is Door)
                {
                    IDoor tempDoor = (IDoor)obj;
                    if (tempDoor.Position == location)
                    {
                        objectWithSameLocation = obj;
                    }
                }
                else if (obj is Item)
                {
                    IItem tempItem = (IItem)obj;
                    if (tempItem.Position == location)
                    {
                        objectWithSameLocation = obj;
                    }
                }
            }
            return objectWithSameLocation;
        }

        public override string ToString()
        {
            return ($"Name: {this.name}\n" +
                $"Westroom: {roomName(this.westRoomPtr)}\n" +
                $"NorthRoom: {roomName(this.northRoomPtr)}\n" +
                $"EastRoom: {roomName(this.eastRoomPtr)}\n" +
                $"SouthRoom: {roomName(this.southRoomPtr)}");
        }

        public string roomName(Room room)
        {
            string roomName = "";
            if (room != null)
            {
                roomName = room.name;
            }
            return roomName;
        }
    }
}
