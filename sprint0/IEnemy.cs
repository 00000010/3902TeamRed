using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0
{
    public interface IEnemy : ISprite
    {

        public IEnemy Next();

        public IEnemy Prev();
    }
}
