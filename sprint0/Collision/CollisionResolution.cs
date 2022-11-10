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
            Dictionary<Tuple<string, string>, Type[]> dic = manager.collisionResolutionDic;
            Type[] types = dic.GetValueOrDefault(new Tuple<string, string>(TypeToString(sprite1.GetType()),
                                                TypeToString(sprite2.GetType())));
            ConstructorInfo[] ctors = new ConstructorInfo[types.Count()];
            for (int i = 0; i < types.Count(); i++)
            {
                ctors[i] = types[i].GetConstructor(new[] { typeof(IObject), typeof(IObject), typeof(string), typeof(GameObjectManager) });
            }
            ICommand command;
            foreach (ConstructorInfo ctor in ctors)
            {
                if (ctor != null)
                {
                    object[] collidingObjects = new object[] { sprite1, sprite2, intersectionLoc, manager };
                    command = (ICommand)ctor.Invoke(collidingObjects);
                    command.Execute();
                }
            }
        }
    }
}
