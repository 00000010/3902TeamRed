using System;
namespace sprint0
{
    public class LinkRectangle : SpriteRectangle
    {
        public LinkRectangle() {}

        public override int SourceX()
        {
            return 0;
        }

        public override int SourceY()
        {
            return 0;
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

