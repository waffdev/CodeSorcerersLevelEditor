using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelEditor
{
    public class RawColor
    {
        public readonly byte R, G, B;

        public RawColor(byte r, byte g, byte b)
        {
            (R, G, B) = (r, g, b);
        }
    }
}
