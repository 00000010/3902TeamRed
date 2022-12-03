using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0
{
    internal class TitleScreenCommand : ICommand
    {
        private Game1 game;
        private Direction direction;
        private Vector2[] position;
        private int totalPositions;
        private int currentPosition;
        public TitleScreenCommand(Game1 game, Direction direction)
        {
            this.game = game;
            this.direction = direction;

            position = new Vector2[3];
            totalPositions = position.Length;

            for (int i = 0; i < totalPositions; i++)
            {
                position[i] = new Vector2(250, 310 + (i * 50));
            }
        }

        public void Execute()
        {

            for (int i = 0; i < totalPositions; i++)
            {
                if (game.cursor.Position == position[i])
                {
                    currentPosition = i;
                    break;
                }
            }

            switch (direction)
            {
                case Direction.UP:
                    currentPosition--;
                    if (currentPosition < 0)
                    {
                        currentPosition = totalPositions - 1;
                    }
                    break;
                case Direction.DOWN:
                    currentPosition++;
                    if (currentPosition >= totalPositions)
                    {
                        currentPosition = 0;
                    }
                    break;
                case Direction.RIGHT:
                    if (game.cursor.Position == position[0])
                    {
                        game.keyboard.UnloadKeys();
                        game.keyboard.LoadDefaultKeys(game);
                        HandleSpecialDisplays.Instance.TitleScreen = false;
                        game.manager.RemoveObject(game.cursor);
                        game.loader.UnloadRoom();
                        game.loader.LoadLevel("Dungeon1");
                        game.player.Position = new Vector2(Constants.FROM_DOWN_LINK_POSITION_X, Constants.FROM_DOWN_LINK_POSITION_Y);
                        game.manager.player.Position = new Vector2(Constants.FROM_DOWN_LINK_POSITION_X, Constants.FROM_DOWN_LINK_POSITION_Y);
                    }
                    else if (game.cursor.Position == position[1])
                    {
                        game.keyboard.UnloadKeys();
                        game.keyboard.LoadLevelSelectScreenKeys(game);
                        HandleSpecialDisplays.Instance.TitleScreen = false;
                        HandleSpecialDisplays.Instance.LevelSelectScreen = true;
                        game.cursor.Position = position[0];
                        game.loader.UnloadRoom();
                        game.loader.LoadLevel("LevelSelectScreen");
                    }
                    else if (game.cursor.Position == position[2])
                    {
                        game.keyboard.UnloadKeys();
                        game.keyboard.LoadLevelCreatorKeys(game);
                        HandleSpecialDisplays.Instance.TitleScreen = false;
                        HandleSpecialDisplays.Instance.LevelCreatorScreen = true;
                        game.manager.RemoveObject(game.cursor);
                        game.loader.UnloadRoom();
                        game.loader.clearLoader();
                        game.creator.numLevels = 1;
                        game.creator.loadLevelCreator();
                        game.player.Position = new Vector2(-180, -120);
                        game.manager.player.Position = new Vector2(-180, -120);
                        game.mouse.LoadLevelCreatorCommands(game, game.loader);
                    }
                    break;
                default:
                    break;
            }

            if (HandleSpecialDisplays.Instance.TitleScreen)
            {
                game.cursor.Position = position[currentPosition];
            }
        }
    }
}