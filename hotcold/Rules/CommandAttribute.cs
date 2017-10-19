using System;
using System.Collections.Generic;
using System.Text;

namespace Epsilon.Rules
{
    public class CommandAttribute : System.Attribute
    {
        public int Command;
        public string Name;
        public double Version;

        public CommandAttribute(int command, string name, double version)
        {
            this.Command = command;
            this.Name = name;
            this.Version = version;
        }
    }
}
