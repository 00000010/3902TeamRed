using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace sprint0
{
    //internal class LevelSelectScreenStartGameCommand : ICommand
    //{
    //    private Game1 game;

    //    public LevelSelectScreenStartGameCommand(Game1 game)
    //    {
    //        this.game = game;
    //    }

    //    public void Execute()
    //    {
    //        game.keyboard.LoadDefaultKeys(game);
    //        game.loader.UnloadRoom();
    //        game.loader.LoadLevel("Dungeon1");
    //        // player is hidden off screen
    //        game.player.Position = new Vector2(Constants.FROM_DOWN_LINK_POSITION_X, Constants.FROM_DOWN_LINK_POSITION_Y);

    //    }
    //}

    internal class LevelSelectScreenCommand : ICommand
    {
        private Game1 game;
        private Direction direction;
        private int totalLevels;
        private int currentLevel;
        private Vector2[] position;
        private string levelPath;
        private string[] levels;

        public LevelSelectScreenCommand(Game1 game, Direction direction)
        {
            this.game = game;
            this.direction = direction;
            levelPath = GetLevelPath();
            totalLevels = GetTotalLevels();
            levels = GetLevelNames();
            currentLevel = 0;

            position = new Vector2[totalLevels];

            for (int i = 0; i < totalLevels; i++)
            {
                position[i] = new Vector2(250, 310 + (i * 50));
            }
        }

        private string GetLevelPath()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @$"..\..\..\Levels\");
            }
            else
            {
                return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @$"../../../Levels/");
            }
        }

        private int GetTotalLevels()
        {
            // totalLevels doesn't need to include TitleScreen, LevelSelectScreen, or LevelCreator
            return Directory.GetDirectories(levelPath).Length - 3;
        }

        private string[] GetLevelNames()
        {
            string[] names = new string[totalLevels];

            int i = 0;
            foreach (string s in Directory.GetDirectories(levelPath))
            {

                string level;

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    level = s.Substring(s.LastIndexOf('\\') + 1);
                }
                else
                {
                    level = s.Substring(s.LastIndexOf('/') + 1);
                }

                if (!(level.Equals("TitleScreen") || level.Equals("LevelSelectScreen") || level.Equals("LevelCreator")))
                {
                    names[i] = level;
                    i++;
                }
            }

            return names;
        }

        public void Execute()
        {

            for (int i = 0; i < totalLevels; i++)
            {
                if (game.cursor.Position == position[i])
                {
                    currentLevel = i;
                    break;
                }
            }
                       
            switch (direction)
            {
                case Direction.UP:
                    currentLevel--;
                    if (currentLevel < 0)
                    {
                        currentLevel = totalLevels - 1;
                    }
                    break;
                case Direction.DOWN:
                    currentLevel++;
                    if (currentLevel >= totalLevels)
                    {
                        currentLevel = 0;
                    }
                    break;
                case Direction.RIGHT:
                    game.keyboard.UnloadKeys();
                    game.keyboard.LoadDefaultKeys(game);
                    game.loader.UnloadRoom();
                    game.manager.RemoveObject(game.cursor);
                    game.player.Position = new Vector2(Constants.FROM_DOWN_LINK_POSITION_X, Constants.FROM_DOWN_LINK_POSITION_Y);
                    game.manager.player.Position = new Vector2(Constants.FROM_DOWN_LINK_POSITION_X, Constants.FROM_DOWN_LINK_POSITION_Y);
                    game.loader.LoadLevel(levels[currentLevel]);
                    break;
                case Direction.LEFT:
                    game.keyboard.UnloadKeys();
                    game.keyboard.LoadTitleScreenKeys(game);
                    HandleSpecialDisplays.Instance.LevelSelectScreen = false;
                    HandleSpecialDisplays.Instance.TitleScreen = true;
                    game.cursor.Position = position[1];
                    game.loader.UnloadRoom();
                    game.loader.LoadLevel("TitleScreen");

                    break;
                default:
                    break;
            }

            if (HandleSpecialDisplays.Instance.LevelSelectScreen)
            {
                game.cursor.Position = position[currentLevel];
            }
        }
    }
}
