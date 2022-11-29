using System;
using System.Diagnostics;
using System.Reflection;
using Microsoft.Xna.Framework;

namespace sprint0
{
    public class PlaceBlockCommand : ICommand
    {

        Vector2 location;
        Game1 game;

        public PlaceBlockCommand(Game1 game, Vector2 location)
        {
            this.location = location;
            this.game = game;
        }

        public void Execute()
        {
            Room currentRoom = game.loader.currentRoom;
            GameObjectManager manager = game.manager;

            Debug.WriteLine("TEST " + location);
            object objectToPlace = game.creator.currentObject;

            if (!currentRoom.existsInLocation(location))
            {
                if (objectToPlace is Block)
                {
                    IBlock tempBlock = (IBlock)objectToPlace;
                    Debug.WriteLine(tempBlock.GetType() + " HI");

                    string blockType = tempBlock.GetType().ToString();
                    string kindOnly = blockType.Substring(blockType.LastIndexOf('.') + 1);

                    object newBlock = createNewObj("Block", kindOnly, location);

                    manager.AddObject(newBlock);
                    currentRoom.Add(newBlock);
                }
                else if (objectToPlace is Item)
                {
                    IItem tempItem = (IItem)objectToPlace;

                    string itemType = tempItem.GetType().ToString();
                    string kindOnly = itemType.Substring(itemType.LastIndexOf('.') + 1);

                    object newItem = createNewObj("Item", kindOnly, location);

                    manager.AddObject(newItem);
                    currentRoom.Add(newItem);
                }
                else if (objectToPlace is Enemy)
                {
                    IEnemy tempEnemy = (IEnemy)objectToPlace;
                    Debug.WriteLine(tempEnemy.GetType() + " HI");

                    string enemyType = tempEnemy.GetType().ToString();
                    string kindOnly = enemyType.Substring(enemyType.LastIndexOf('.') + 1);

                    object newEnemy = createNewObj("Enemy", kindOnly, location);

                    Enemy noVelocityEnemy = (Enemy)newEnemy;
                    noVelocityEnemy.willUpdateVelocity = false;

                    manager.AddObject(noVelocityEnemy);
                    currentRoom.Add(newEnemy);

                }
            }

        }
        public object createNewObj(string stringType, string objName, Vector2 position)
        {
            Object objectCreated = new object();
            Object objectClass = new object();
            MethodInfo method;

            object[] parameterArray = { position };

            string factoryString = GetThisNamespace() + "." + stringType + "Factory"; // get type name
            Type type = Type.GetType(factoryString); // get type from name
            objectClass = type.InvokeMember("Instance", BindingFlags.GetProperty, null, null, null); // get class from type
            method = objectClass.GetType().GetMethod(objName); // get method from class and method name
            objectCreated = method.Invoke(objectClass, parameterArray); // call method and get its object

            return objectCreated;
        }

        private string GetThisNamespace()
        {
            return GetType().Namespace;
        }
    }
}