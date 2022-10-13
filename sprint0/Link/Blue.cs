using System;
using sprint0.Rectangles;

namespace sprint0
{
    public class Blue : RectangleColorDecorator
    {
        SpriteRectangle spriteRectangle;

        public Blue(SpriteRectangle spriteRectangle)
        {
            this.spriteRectangle = spriteRectangle;
        }

        public override int SourceX()
        {
            return spriteRectangle.SourceX() + Constants.LINK_WIDTH * 4;
        }

        public override int SourceY()
        {
            return spriteRectangle.SourceY();
        }

        public override int SourceWidth()
        {
            return spriteRectangle.SourceWidth();
        }

        public override int SourceHeight()
        {
            return spriteRectangle.SourceHeight();
        }

        public override int Frames()
        {
            return spriteRectangle.Frames();
        }

        public override int Colors()
        {
            return spriteRectangle.Colors();
        }
    }
}

