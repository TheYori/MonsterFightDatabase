using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterFightDatabase.Class
{
    public class Button : Component
    {
        public Action action;

        public Button(Action action)
        {
            this.action = action;
        }

        public override string ToString()
        {
            return "Button";
        }
    }
}
