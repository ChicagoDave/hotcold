using System;
using System.Runtime;
using System.Collections.Generic;
using System.Collections;
using System.Reflection;
using System.Text;

namespace Epsilon.Rules
{
    public static class ClothingRulesFactory
    {
        private static Type[] types = null;

        public static IClothingRule GetRule(int command)
        {
            // We only need to read this the first time...probably should refactor to dispose...
            if (types == null)
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                types = assembly.GetExportedTypes();
            }

            // Loop through types for rules (types with custom attribute CommandAttribute)
            foreach (Type type in types)
            {
                CommandAttribute attribute = (CommandAttribute)Attribute.GetCustomAttribute(type, typeof(CommandAttribute));

                if (attribute != null && attribute.Command == command)
                {
                    // Found the requested type, return instance...
                    return (IClothingRule)Activator.CreateInstance(type);
                }
            }

            throw new Exception("Invalid command. There is no rule associated with " + command.ToString());
        }
    }
}
