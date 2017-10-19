using System;
using System.Collections.Generic;
using System.Text;
using Epsilon.Wearables;

using Epsilon.People;

namespace Epsilon.Rules
{
    [Command(7, "leave house", 1.0)]
    public class LeaveHouseRule : IClothingRule
    {
        public ClothingResponse Execute(ref Person person, Weather weather)
        {
            ClothingResponse response = new ClothingResponse()
            {
                IsSuccessful = false,
                Response = "fail"
            };

            if (person.IsWearing(Clothing.Pajamas)) return response;
            if (!person.IsWearing(Clothing.Footwear)) return response;
            if (!person.IsWearing(Clothing.Headwear)) return response;
            if (!person.IsWearing(Clothing.Socks) && weather == Weather.Cold) return response;
            if (!person.IsWearing(Clothing.Shirt)) return response;
            if (!person.IsWearing(Clothing.Jacket) && weather == Weather.Cold) return response;
            if (!person.IsWearing(Clothing.Pants)) return response;

            return new ClothingResponse()
            {
                IsSuccessful = true,
                Response = "leaving house"
            };
        }
    }
}
