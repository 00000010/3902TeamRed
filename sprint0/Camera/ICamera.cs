using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace sprint0
{
    public interface ICamera : IUpdateable
    {
        // TODO: make pass room objects by reference?
        public void CurtainTransition(List<Sprite> prevRoomObjects, List<Sprite> nextRoomObjects, GameTime gameTime);
        public void PanLeftTransition(List<Sprite> prevRoomObjects, List<Sprite> nextRoomObjects, GameTime gameTime);
        public void PanRightTransition(List<Sprite> prevRoomObjects, List<Sprite> nextRoomObjects, GameTime gameTime);
        public void PanUpTransition(List<Sprite> prevRoomObjects, List<Sprite> nextRoomObjects, GameTime gameTime);
        public void PanDownTransition(List<Sprite> prevRoomObjects, List<Sprite> nextRoomObjects, GameTime gameTime);
    }
}