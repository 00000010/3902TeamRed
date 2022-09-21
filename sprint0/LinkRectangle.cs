using System;
namespace sprint0
{
    public class LinkRectangle : SpriteRectangle
    {
        private int x = 0;
        private int y = 0;

        public LinkRectangle(int x = 0, int y = 0) {
            this.x = x;
            this.y = y;
        }

        public override int SourceX()
        {
            return this.x;
        }

        public override int SourceY()
        {
            return this.y;
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
            return 1;
        }

        public override int Colors()
        {
            return 1;
        }
    }
}

