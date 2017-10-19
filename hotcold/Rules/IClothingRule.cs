using System;
using System.Collections.Generic;
using System.Text;

using Epsilon.Wearables;
using Epsilon.People;

namespace Epsilon.Rules
{
    public interface IClothingRule
    {
        ClothingResponse Execute(ref Person person, Weather weather);
    }
}
