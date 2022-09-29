using System;
namespace sprint0
{
    public class Damaged : RectangleStateDecorator
    {
        SpriteRectangle spriteRectangle;

        //TODO: When Link is running, he appears to being twice as fast; fix this

        public Damaged(SpriteRectangle spriteRectangle)
        {
            Console.WriteLine("Damaged called");
            this.spriteRectangle = spriteRectangle;
        }

        public override int SourceX()
        {
            return this.spriteRectangle.SourceX();
        }

        public override int SourceY()
        {
            return this.spriteRectangle.SourceY();
        }

        public override int SourceWidth()
        {
            return spriteRectangle.SourceWidth() * Constants.NUM_OF_DIRECTIONS * Constants.NUM_OF_COLORS;
        }

        public override int SourceHeight()
        {
            return spriteRectangle.SourceHeight();
        }

        public override int Frames()
        {
            int frames = spriteRectangle.Frames();
            Console.WriteLine("frames before: " + frames);
            if (frames == 1 || frames == 2)
            {
                frames = frames * 3;
            }
            Console.WriteLine("frames after: " + frames);
            return frames;
        }

        public override int Colors()
        {
            return Constants.NUM_OF_COLORS;
        }
    }
}

