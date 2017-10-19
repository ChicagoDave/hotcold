using System;
using System.Collections.Generic;
using System.Text;
using Epsilon.Wearables;

using Epsilon.People;

namespace Epsilon.Rules
{
    [Command(1, "footwear", 1.0)]
    public class FootwearRule : IClothingRule
    {
        public ClothingResponse Execute(ref Person person, Weather weather)
        {
            ClothingResponse response = new ClothingResponse()
            {
                IsSuccessful = false,
                Response = "fail"
            };

            if (person.IsWearing(Clothing.Footwear)) return response;
            if (person.IsWearing(Clothing.Pajamas)) return response;
            if (!person.IsWearing(Clothing.Pants)) return response;
            if (!person.IsWearing(Clothing.Socks) && weather == Weather.Cold) return response;

            person.Wear(Clothing.Footwear);

            return new ClothingResponse()
            {
                IsSuccessful = true,
                Response = weather == Weather.Hot ? "sandals" : "boots"
            };
        }
    }
}
