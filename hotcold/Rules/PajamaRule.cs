using System;
using System.Collections.Generic;
using System.Text;

using Epsilon.Wearables;
using Epsilon.People;

namespace Epsilon.Rules
{
    [Command(8, "pajamas", 1.0)]
    public class PajamaRule : IClothingRule
    {
        public ClothingResponse Execute(ref Person person, Weather weather)
        {
            ClothingResponse response = new ClothingResponse()
            {
                IsSuccessful = false,
                Response = "fail"
            };

            if (person.IsWearing(Clothing.Pajamas))
            {
                person.Remove(Clothing.Pajamas);
                response = new ClothingResponse()
                {
                    IsSuccessful = true,
                    Response = "removing PJ's"
                };
            } 

            return response;
        }
    }
}
