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
            return Constants.LINK_HEIGHT * 2;
        }

        public override int SourceWidth()
        {
            return spriteRectangle.SourceWidth();
        }

        public override int SourceHeight()
        {
            return spriteRectangle.SourceHeight() + Constants.LINK_HEIGHT;
        }

        public override int Frames()
        {
            int frames = 2; // not damaged => 2 frames
            if (spriteRectangle.Frames() > 2) // damaged => 6 frames
            {
                frames = 6;
            }
            return frames;
        }

        public override int Colors()
        {
            return spriteRectangle.Colors();
        }
    }
}

