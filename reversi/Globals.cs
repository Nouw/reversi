using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reversi
{
    internal static class Globals
    {
        //Internal representation of the game area
        //0 = empty, 1 = blue, 2 = red
        public static int[,] internalGameArea = new int[6, 6];
    }
}
