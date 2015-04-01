using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileAutoBuy
{
    using ICities;
    public class TileAutoBuy : IUserMod
    {
        public string Name
        {
            get { return "TileAutoBuy"; }
        }

        public string Description
        {
            get { return "Automatically buy all tiles on game start"; }
        }
    }
}
