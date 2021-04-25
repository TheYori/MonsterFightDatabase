using MonsterFightDatabase.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterFightDatabase.Component.MonsterParts
{
    public class Arms : MonsterPart
    {
        public int Strength { get; set; }
        public int Speed { get; set; }
        public Arms(int monsterId, int partId, string name, string rank, string alligment, int price, int strength, int speed) : base(monsterId, partId, name, rank, alligment, price)
        {
            this.Strength = strength;
            this.Speed = speed;
        }

        public override string ToString()
        {
            return "arms";
        }
    }
}
