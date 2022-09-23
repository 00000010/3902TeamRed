using System;
namespace sprint0
{
    public class LinkRectangle : SpriteRectangle
    {
        private int x, y, frames;

        public LinkRectangle(int x = 0, int y = 0, int frames = 1) {
            this.x = x;
            this.y = y;
            /*
             * TODO: hardcoded logic like this seems bad...
             * Purpose is to get correct frames per color otherwise will keep multiplying by 3
             * if do this.frames = frames
             */
            this.frames = frames / Constants.NUM_OF_COLORS + frames % Constants.NUM_OF_COLORS;
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
            return 1;
        }
    }
}

