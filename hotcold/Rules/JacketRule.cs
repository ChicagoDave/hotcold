using System;
using System.Collections.Generic;
using System.Text;
using Epsilon.Wearables;

using Epsilon.People;

namespace Epsilon.Rules
{
    [Command(5, "jacket", 1.0)]
    public class JacketRule : IClothingRule
    {
        public ClothingResponse Execute(ref Person person, Weather weather)
        {
            ClothingResponse response = new ClothingResponse()
            {
                IsSuccessful = false,
                Response = "fail"
            };

            if (person.IsWearing(Clothing.Jacket)) return response;
            if (person.IsWearing(Clothing.Pajamas)) return response;
            if (weather == Weather.Hot) return response;

            if (!person.IsWearing(Clothing.Shirt)) return response;

            person.Wear(Clothing.Jacket);

            return new ClothingResponse()
            {
                IsSuccessful = true,
                Response = "jacket"
            };
        }
    }
}
