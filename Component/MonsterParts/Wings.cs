using MonsterFightDatabase.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterFightDatabase.Component.MonsterParts
{
    public class Wings : MonsterPart
    {
        public int Speed { get; set; }
        public int Agility { get; set; }
        public Wings(int monsterId, int partId, string name, string rank, string alligment, int price, int speed, int agility) : base(monsterId, partId, name, rank, alligment, price)
        {
            this.Speed = speed;
            this.Agility = agility;
        }

        public override string ToString()
        {
            return "wings";
        }
    }
}
