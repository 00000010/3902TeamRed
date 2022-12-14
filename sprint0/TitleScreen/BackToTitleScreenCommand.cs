using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0
{
    internal class BackToTitleScreenCommand : ICommand
    {
        Game1 game;

        private Vector2[] position;
        private int totalPositions;
        private GameState state;

        public BackToTitleScreenCommand(Game1 game, GameState state)
        {
            this.game = game;
            this.state = state;

            position = new Vector2[3];
            totalPositions = position.Length;

            for (int i = 0; i < totalPositions; i++)
            {
                position[i] = new Vector2(250, 310 + (i * 50));
            }
        }

        public void Execute()
        {
            LevelLoader loader = game.loader;
            LevelCreator creator = game.creator;
            GameObjectManager manager = game.manager;




            if (state == GameState.CREATOR)
            {
                loader.UnloadRoom();
                loader.currentRoom = creator.gridRoom;
                loader.UnloadRoom();
                game.creator.unloadCreator();
            }
            if (state == GameState.GAME)
            {
                loader.UnloadRoom();
            }

            
            game.mouse.unloadCommands();
            game.keyboard.UnloadKeys();
            game.keyboard.LoadTitleScreenKeys(game);
            HandleSpecialDisplays.Instance.LevelSelectScreen = false;
            HandleSpecialDisplays.Instance.LevelCreatorScreen = false;
            HandleSpecialDisplays.Instance.Room10 = false;
            HandleSpecialDisplays.Instance.TitleScreen = true;
            game.loader.clearLoader();
            game.loader.LoadLevel("TitleScreen");
            game.manager.AddObject(game.cursor);
            game.cursor.Position = position[0];
            game.player.Position = new Vector2(-180, -120);
            game.manager.player.Position = new Vector2(-180, -120);
            game.map.UnloadMap();
        }
    }
}
