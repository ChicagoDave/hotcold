using System;
using System.Collections.Generic;
using System.Text;
using Epsilon.Wearables;

using Epsilon.People;

namespace Epsilon.Rules
{
    [Command(3, "socks", 1.0)]
    public class SocksRule : IClothingRule
    {
        public ClothingResponse Execute(ref Person person, Weather weather)
        {
            ClothingResponse response = new ClothingResponse()
            {
                IsSuccessful = false,
                Response = "fail"
            };

            if (weather == Weather.Hot) return response;
            if (person.IsWearing(Clothing.Socks)) return response;
            if (person.IsWearing(Clothing.Pajamas)) return response;

            person.Wear(Clothing.Socks);

            return new ClothingResponse()
            {
                IsSuccessful = true,
                Response = "socks"
            };
        }
    }
}
