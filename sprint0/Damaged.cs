﻿using System;
namespace sprint0
{
    public class Damaged : RectangleStateDecorator
    {
        SpriteRectangle spriteRectangle;

        public Damaged(SpriteRectangle spriteRectangle)
        {
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
            return spriteRectangle.Frames();
        }

        public override int Colors()
        {
            return 3;
        }
    }
}

