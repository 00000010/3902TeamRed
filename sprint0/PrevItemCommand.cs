using sprint0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sprint0
{
    public class PrevItemCommand : ICommand
    {
        private Game1 game;
        public PrevItemCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.manager.RemoveObject(game.item);

            if (game.item is ZeldaBlueCandle)
            {
                game.item = ItemFactory.Instance.ZeldaKey(game.item.Position);
            }
            else if (game.item is ZeldaBomb)
            {
                game.item = ItemFactory.Instance.ZeldaBlueCandle(game.item.Position);
            }
            else if (game.item is ZeldaBoomerang)
            {
                game.item = ItemFactory.Instance.ZeldaBomb(game.item.Position);
            }
            else if (game.item is ZeldaBow)
            {
                game.item = ItemFactory.Instance.ZeldaBoomerang(game.item.Position);
            }
            else if (game.item is ZeldaClock)
            {
                game.item = ItemFactory.Instance.ZeldaBow(game.item.Position);
            }
            else if (game.item is ZeldaCompass)
            {
                game.item = ItemFactory.Instance.ZeldaClock(game.item.Position);
            }
            else if (game.item is ZeldaFairy)
            {
                game.item = ItemFactory.Instance.ZeldaCompass(game.item.Position);
            }
            else if (game.item is ZeldaFood)
            {
                game.item = ItemFactory.Instance.ZeldaFairy(game.item.Position);
            }
            else if (game.item is ZeldaHeart)
            {
                game.item = ItemFactory.Instance.ZeldaFood(game.item.Position);
            }
            else if (game.item is ZeldaKey)
            {
                game.item = ItemFactory.Instance.ZeldaHeart(game.item.Position);
            }

            game.manager.AddObject(game.item);
        }
    }
}

