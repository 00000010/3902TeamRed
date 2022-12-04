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
        public bool Transitioning { get; set; }
        public bool TransitionSet { get; set; }
        // TODO: make pass room objects by reference?
        public void CurtainTransition(List<object> prevRoomObjects, List<object> nextRoomObjects);
        public void PanLeftTransition(List<Sprite> prevRoomSprites, List<Sprite> nextRoomSprites);
        public void PanRightTransition(List<Sprite> prevRoomSprites, List<Sprite> nextRoomSprites);
        public void PanUpTransition(List<Sprite> prevRoomSprites, List<Sprite> nextRoomSprites);
        public void PanDownTransition(List<Sprite> prevRoomSprites, List<Sprite> nextRoomSprites);
    }
}