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
        public void PanLeftTransition();
        public void PanRightTransition();
        public void PanUpTransition();
        public void PanDownTransition();
    }
}