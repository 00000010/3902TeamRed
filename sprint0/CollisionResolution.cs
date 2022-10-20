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
            //Dictionary<Tuple<Type, Type>, Type> dic = manager.collisionResolutionDic;
            //Type type = dic.GetValueOrDefault(new Tuple<Type, Type>(sprite1.GetType(), sprite2.GetType()));
            //ConstructorInfo ctor = type.GetConstructor(new[] { typeof(IObject), typeof(IObject), typeof(string), typeof(GameObjectManager) });
            //ICommand command;
            //if (ctor != null)
            //{
            //    object[] collidingObjects = new object[] { sprite1, sprite2, intersectionLoc, manager };
            //    command = (ICommand)ctor.Invoke(collidingObjects);
            //    command.Execute();
            //}
        }
    }
}