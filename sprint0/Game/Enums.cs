using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0
{
    public enum State { STANDING, RUNNING, ATTACKING, THROWING }
    public enum Direction { LEFT, RIGHT, UP, DOWN }
    public enum TypeOfProj { ARROW, BOOMERANG, FIRE}
    public enum KeyboardAction { UP, DOWN, LEFT, RIGHT, PAUSE, RESUME, RESTART, SHOWINVENTORY, 
        HIDEINVENTORY, SHOOT, STAB, EXIT, NEXTPROJECTILE, PREVPROJECTILE, SHOWCONTROLS, HIDECONTROLS, ENTER, ESCAPE, FAULTY }

    public enum GameState { CREATOR, GAME }

    public enum Cardinal { NORTH, EAST, SOUTH, WEST, NONE }
    internal class Enums
    {
        private Enums() { }
    }
}
