using System;
namespace sprint0
{
    public class Red : RectangleColorDecorator
    {
        SpriteRectangle spriteRectangle;

        public Red(SpriteRectangle spriteRectangle)
        {
            this.spriteRectangle = spriteRectangle;
        }

        public override int SourceX()
        {
            return spriteRectangle.SourceX() + Constants.LINK_WIDTH * 8;
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

