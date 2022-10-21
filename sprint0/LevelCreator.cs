using System;
using Microsoft.Xna.Framework;

namespace sprint0
{
    public class LevelCreator
    {
        LevelLoader loader;
        MouseController mouse;

        public LevelCreator(Game1 game, Vector2 resolution)
        {
            this.loader = new LevelLoader(game);
            this.loader.LoadLevel("LevelCreator");
            Console.WriteLine(loader.ToString());
            this.mouse = new MouseController(resolution);
            this.mouse.LoadLevelCreatorCommands(game, loader);
            game.updateables.Add(mouse);
        }

    }
}

