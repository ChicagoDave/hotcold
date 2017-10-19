using System;
using System.Collections.Generic;
using System.Text;

namespace Epsilon.Wearables
{
    [Flags]
    public enum Clothing : short
    {
        Pajamas = 1,
        Headwear = 2,
        Footwear = 4,
        Socks = 8,
        Shirt = 16,
        Pants = 32,
        Jacket = 64
    }
}
