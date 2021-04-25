using MonsterFightDatabase.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterFightDatabase.Component.MonsterParts
{
    public class Body : MonsterPart
    {
        public int Defence { get; set; }
        public int Health { get; set; }
        public Body(int monsterId, int partId, string name, string rank, string alligment, int price, int defence, int health) : base(monsterId, partId, name, rank, alligment, price)
        {
            this.Defence = defence;
            this.Health = health;
        }

        public override string ToString()
        {
            return "body";
        }
    }
}
