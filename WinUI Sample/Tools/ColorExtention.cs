using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public static class ColorExtention
    {
        public static bool IsABrightColor(this Windows.UI.Color color)
        {
            if (color.R >= 127) return true;
            if (color.G >= 127) return true;
            if (color.B >= 127) return true;
            return false;
        }
    }
}
