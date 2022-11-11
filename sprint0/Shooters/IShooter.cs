using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0
{
    public interface IShooter
    {
        public bool ShotBoomerang { get; set; }
        public string TypeOfObject { get; set; }
    }
}
