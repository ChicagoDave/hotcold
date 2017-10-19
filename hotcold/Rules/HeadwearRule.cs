using System;
using System.Collections.Generic;
using System.Text;
using Epsilon.Wearables;

using Epsilon.People;

namespace Epsilon.Rules
{
    [Command(2, "headwear", 1.0)]
    public class HeadwearRule : IClothingRule
    {
        public ClothingResponse Execute(ref Person person, Weather weather)
        {
            ClothingResponse response = new ClothingResponse()
            {
                IsSuccessful = false,
                Response = "fail"
            };

            if (person.IsWearing(Clothing.Headwear)) return response;
            if (person.IsWearing(Clothing.Pajamas)) return response;
            if (!person.IsWearing(Clothing.Shirt)) return response;

            person.Wear(Clothing.Headwear);

            return new ClothingResponse()
            {
                IsSuccessful = true,
                Response = weather == Weather.Hot ? "sun visor" : "hat"
            };
        }
    }
}
