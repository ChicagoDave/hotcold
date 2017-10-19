using System;
using System.Collections.Generic;
using System.Text;

using Epsilon.Rules;
using Epsilon.Wearables;

namespace Epsilon.People
{
    public class Person
    {
        public Clothing Wearing { get; set; }

        public bool IsWearing(Clothing clothing)
        {
            return this.Wearing.HasFlag(clothing);
        }

        public void Wear(Clothing clothing)
        {
            this.Wearing = this.Wearing | clothing;
        }

        public void Remove(Clothing clothing)
        {
            this.Wearing &= ~clothing;
        }

    }
}
