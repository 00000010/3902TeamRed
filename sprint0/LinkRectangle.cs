using System;
namespace sprint0
{
    public class LinkRectangle : SpriteRectangle
    {
        private int x, y, frames;

        public LinkRectangle(int x = 0, int y = 0, int frames = 1) {
            this.x = x;
            this.y = y;
            this.frames = frames;
        }

        public override int SourceX()
        {
            return x;
        }

        public override int SourceY()
        {
            return y;
        }

        public override int SourceWidth()
        {
            return Constants.LINK_WIDTH;
        }

        public override int SourceHeight()
        {
            return Constants.LINK_HEIGHT;
        }

        public override int Frames()
        {
            return frames;
        }

        public override int Colors()
        {
            int colors = 1;
            if (frames % Constants.NUM_OF_COLORS == 0)
            {
                colors = 3;
            }
            return colors;
        }
    }
}

