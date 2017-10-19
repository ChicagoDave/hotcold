using System;
using System.Collections.Generic;
using System.Text;
using Epsilon.Wearables;

using Epsilon.People;

namespace Epsilon.Rules
{
    [Command(6, "pants", 1.0)]
    public class PantsRule : IClothingRule
    {
        public ClothingResponse Execute(ref Person person, Weather weather)
        {
            ClothingResponse response = new ClothingResponse()
            {
                IsSuccessful = false,
                Response = "fail"
            };

            if (person.IsWearing(Clothing.Pants)) return response;
            if (person.IsWearing(Clothing.Pajamas)) return response;

            person.Wear(Clothing.Pants);

            return new ClothingResponse()
            {
                IsSuccessful = true,
                Response = weather == Weather.Hot ? "shorts" : "pants"
            };
        }
    }
}
