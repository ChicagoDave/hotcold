using System;
using System.Collections.Generic;

using Epsilon.People;
using Epsilon.Rules;
using Epsilon.Wearables;

namespace Epsilon
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> arguments = new List<string>();
            List<int> actions = new List<int>();
            Weather weather = Weather.Hot;

            if (args.Length == 0)
            {
                Console.WriteLine("HOTCOLD - Usage: HOTCOLD [HOT|COLD] list of space+comma separated numbered actions");
                Console.WriteLine("Actions: 1 - Put on footwear (HOT:sandals or COLD:boots)");
                Console.WriteLine("Actions: 2 - Put on headwear (HOT:sub visor or COLD:hat)");
                Console.WriteLine("Actions: 3 - Put on socks (HOT:fail or COLD:socks)");
                Console.WriteLine("Actions: 4 - Put on shirt (HOT:t-shirt or COLD:shirt)");
                Console.WriteLine("Actions: 5 - Put on jacket (HOT:fail or COLD:jacket)");
                Console.WriteLine("Actions: 6 - Put on pants (HOT:shorts or COLD:pants)");
                Console.WriteLine("Actions: 7 - Leave House (HOT:leaving house or COLD:leaving house)");
                Console.WriteLine("Actions: 8 - Take off pajamas (HOT:removing PJ's or COLD:removing PJ's)");
                Console.WriteLine("Example: > hotcold HOT 8, 6, 4, 2, 1, 7");
            }

            Person person = new Person()
            {
                Wearing = Clothing.Pajamas
            };

            try
            {
                weather = args[0].ToLower() == "hot" ? Weather.Hot : Weather.Cold;

                for (int action = 1; action < args.Length; action++)
                    actions.Add(Convert.ToInt32(args[action].Replace(",","")));

            }
            catch
            {
                Console.Write("Invalid list of arguments.");
            }

            ClothingEngine engine = new ClothingEngine(actions);

            engine.ExecuteRules(person, weather);

            Console.WriteLine();
        }
    }
}
