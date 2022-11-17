using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Microsoft.Xna.Framework;

namespace sprint0
{
    public class LevelCreator
    {
        LevelLoader loader;
        MouseController mouse;
        public List<XElement> XmlObjs = new List<XElement>();

        public LevelCreator(Game1 game)
        {
            this.loader = game.loader;
            this.mouse = game.mouse;
            mouse.LoadLevelCreatorCommands(game, loader);
        }

    }
}