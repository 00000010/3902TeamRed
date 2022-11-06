using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static sprint0.SpriteRectangle;

namespace sprint0
{
    internal class ItemFactory
    {
        private static ItemFactory instance = new ItemFactory();
        public static ItemFactory Instance
        {
            get
            {
                return instance;
            }
        }
        private ItemFactory() { }
        public Item ZeldaBlueCandle(Vector2 position)
        {
            return new ZeldaBlueCandle(position);
        }

        public Item ZeldaBomb(Vector2 position)
        {
            return new ZeldaBomb(position);
        }

        public Item ZeldaBoomerang(Vector2 position)
        {
            return new ZeldaBoomerang(position);
        }
        
        public Item ZeldaBow(Vector2 position)
        {
            return new ZeldaBow(position);
        }

        public Item ZeldaClock(Vector2 position)
        {
            return new ZeldaClock(position);
        }

        public Item ZeldaCompass(Vector2 position)
        {
            return new ZeldaCompass(position);
        }

        public Item ZeldaFairy(Vector2 position)
        {
            return new ZeldaFairy(position);
        }

        public Item ZeldaFood(Vector2 position)
        {
            return new ZeldaFood(position);
        }

        public Item ZeldaHeart(Vector2 position)
        {
            return new ZeldaHeart(position);
        }

        public Item ZeldaHeartContainer(Vector2 position)
        {
            return new ZeldaHeartContainer(position);
        }

        public Item ZeldaKey(Vector2 position)
        {
            return new ZeldaKey(position);
        }

        public Item ZeldaLetter(Vector2 position)
        {
            return new ZeldaLetter(position);
        }

        public Item ZeldaTriforce(Vector2 position)
        {
            return new ZeldaTriforce(position);
        }
    }

    internal class ZeldaTriforce : Item
    {
        public ZeldaTriforce(Vector2 position)
        {
            Sprite = SpriteFactory.Instance.ZeldaTriforce(position);
        }
    }

    internal class ZeldaBlueCandle : Item
    {
        public ZeldaBlueCandle(Vector2 position)
        {
            Sprite = SpriteFactory.Instance.ZeldaBlueCandle(position);
        }
    }

    internal class ZeldaBomb : Item
    {
        public ZeldaBomb(Vector2 position)
        {
            Sprite = SpriteFactory.Instance.ZeldaBomb(position);
        }
    }

    internal class ZeldaBoomerang : Item
    {
        public ZeldaBoomerang(Vector2 position)
        {
            Sprite = SpriteFactory.Instance.ZeldaBoomerang(position);
        }
    }

    internal class ZeldaBow : Item
    {
        public ZeldaBow(Vector2 position)
        {
            Sprite = SpriteFactory.Instance.ZeldaBow(position);
        }
    }

    internal class ZeldaClock : Item
    {
        public ZeldaClock(Vector2 position)
        {
            Sprite = SpriteFactory.Instance.ZeldaClock(position);
        }
    }

    internal class ZeldaCompass : Item
    {
        public ZeldaCompass(Vector2 position)
        {
            Sprite = SpriteFactory.Instance.ZeldaCompass(position);
        }
    }

    internal class ZeldaFairy : Item
    {
        public ZeldaFairy(Vector2 position)
        {
            Sprite = SpriteFactory.Instance.ZeldaFairy(position);
        }
    }

    internal class ZeldaFood : Item
    {
        public ZeldaFood(Vector2 position)
        {
            Sprite = SpriteFactory.Instance.ZeldaFood(position);
        }
    }

    internal class ZeldaHeart : Item
    {
        public ZeldaHeart(Vector2 position)
        {
            Sprite = SpriteFactory.Instance.ZeldaHeart(position);
        }
    }

    internal class ZeldaHeartContainer : Item
    {
        public ZeldaHeartContainer(Vector2 position)
        {
            Sprite = SpriteFactory.Instance.ZeldaHeartContainer(position);
        }
    }

    internal class ZeldaKey : Item
    {
        public ZeldaKey(Vector2 position)
        {
            Sprite = SpriteFactory.Instance.ZeldaKey(position);
        }
    }

    internal class ZeldaLetter : Item
    {
        public ZeldaLetter(Vector2 position)
        {
            Sprite = SpriteFactory.Instance.ZeldaLetter(position);
        }
    }
}
