using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace sprint0
{
    public class CollisionResolution
    {
        public static void CallCorrespondingCommand(IObject sprite1, IObject sprite2, GameObjectManager manager,
            string intersectionLoc)
        {
            Dictionary<Tuple<string, string>, Type> dic = manager.collisionResolutionDic;
            Type type = dic.GetValueOrDefault(new Tuple<string, string>(TypeToString(sprite1.GetType()), 
                                                TypeToString(sprite2.GetType())));
            ConstructorInfo ctor = type.GetConstructor(new[] { typeof(IObject), typeof(IObject), typeof(string), typeof(GameObjectManager) });
            ICommand command;
            if (ctor != null)
            {
                object[] collidingObjects = new object[] { sprite1, sprite2, intersectionLoc, manager };
                command = (ICommand)ctor.Invoke(collidingObjects);
                command.Execute();
            }
        }

        private static string TypeToString(Type type)
        {
            string result = "";

            if (type.Equals(Type.GetType("sprint0.Link")))
            {
                result = "Link";
            }
            else if (type.Equals(Type.GetType("sprint0.ZeldaBlackBlock")) 
                || type.Equals(Type.GetType("sprint0.ZeldaGreenBlock"))
                || type.Equals(Type.GetType("sprint0.ZeldaPurpleBlock")))
            {
                result = "Block";
            }
            else if (type.Equals(Type.GetType("sprint0.ZeldaBlueCandle"))
                || type.Equals(Type.GetType("sprint0.ZeldaBomb"))
                || type.Equals(Type.GetType("sprint0.ZeldaBoomerang"))
                || type.Equals(Type.GetType("sprint0.ZeldaBow"))
                || type.Equals(Type.GetType("sprint0.ZeldaClock"))
                || type.Equals(Type.GetType("sprint0.ZeldaCompass"))
                || type.Equals(Type.GetType("sprint0.ZeldaFairy"))
                || type.Equals(Type.GetType("sprint0.ZeldaFood"))
                || type.Equals(Type.GetType("sprint0.ZeldaHeart"))
                || type.Equals(Type.GetType("sprint0.ZeldaHeartContainer"))
                || type.Equals(Type.GetType("sprint0.ZeldaKey"))
                || type.Equals(Type.GetType("sprint0.ZeldaLetter")))
            {
                result = "Item";
            }
            else if (type.Equals(Type.GetType("sprint0.Stalfos"))
                || type.Equals(Type.GetType("sprint0.Keese"))
                || type.Equals(Type.GetType("sprint0.Gel"))
                || type.Equals(Type.GetType("sprint0.Goriya"))
                || type.Equals(Type.GetType("sprint0.Octorok")))
            {
                result = "Enemy";
            }

            else if (type.Equals(Type.GetType("sprint0.ZeldaArrow")))
            {
                result = "Projectile";
            }

            return result;
        }
    }
}