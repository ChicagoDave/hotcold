using System;
using System.Collections.Generic;
using System.Text;
using Epsilon.Wearables;

using Epsilon.People;

namespace Epsilon.Rules
{
    [Command(4, "shirt", 1.0)]
    public class ShirtRule : IClothingRule
    {
        public ClothingResponse Execute(ref Person person, Weather weather)
        {
            ClothingResponse response = new ClothingResponse()
            {
                IsSuccessful = false,
                Response = "fail"
            };

            if (person.IsWearing(Clothing.Shirt)) return response;
            if (person.IsWearing(Clothing.Pajamas)) return response;

            person.Wear(Clothing.Shirt);

            if (weather == Weather.Hot)
                return new ClothingResponse()
                {
                    IsSuccessful = true,
                    Response = "t-shirt"
                };
            else
                return new ClothingResponse()
                {
                    IsSuccessful = true,
                    Response = "shirt"
                };
        }
    }
}
