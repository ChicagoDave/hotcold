using System;
using System.Collections.Generic;
using System.Text;

using Epsilon.Wearables;
using Epsilon.People;
using Epsilon.Rules;

namespace Epsilon.Rules
{
    public class ClothingEngine
    {
        List<IClothingRule> rules = new List<IClothingRule>();

        public ClothingEngine(List<int> actions)
        {
            ClothingResponse response = new ClothingResponse()
            {
                IsSuccessful = false,
                Response = "failed"
            };

            // Load the rules in order...
            //
            foreach (int action in actions)
            {
                rules.Add(ClothingRulesFactory.GetRule(action));
            }
        }

        public void ExecuteRules(Person person, Weather weather) {

            // Execute the rules in order...
            //
            foreach (IClothingRule rule in rules)
            {
                //Console.WriteLine("Executing " + rule.GetType().ToString() + "...");

                ClothingResponse response = rule.Execute(ref person, weather);

                Console.Write(response.Response);
                if (response.IsSuccessful && response.Response != "leaving house")
                    Console.Write(", ");

                if (!response.IsSuccessful)
                    return;
            }
        }
    }
}
