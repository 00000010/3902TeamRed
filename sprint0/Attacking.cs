using System;
namespace sprint0
{
    public class Attacking : RectangleStateDecorator
    {
        SpriteRectangle spriteRectangle;

        public Attacking(SpriteRectangle spriteRectangle)
        {
            this.spriteRectangle = spriteRectangle;
        }

        public override int SourceX()
        {
            return spriteRectangle.SourceX();
        }

        // TODO: 2 is a magic number
        public override int SourceY()
        {
            return Constants.LINK_HEIGHT * 2; //spriteRectangle.SourceY() + Constants.LINK_HEIGHT * 2
        }

        public override int SourceWidth()
        {
            return spriteRectangle.SourceWidth();
        }

        public override int SourceHeight()
        {
            return spriteRectangle.SourceHeight() + Constants.LINK_HEIGHT;
        }

        // TODO: 1 is a magic number
        public override int Frames()
        {
            return spriteRectangle.Frames() + 1;
        }

        public override int Colors()
        {
            return spriteRectangle.Colors();
        }
    }
}

