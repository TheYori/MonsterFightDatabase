using MonsterFightDatabase.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterFightDatabase.Component.MonsterParts
{
    public class Tail : MonsterPart
    {
        public int Strength { get; set; }
        public int Agility { get; set; }
        public Tail(int monsterId, int partId, string name, string rank, string alligment, int price, int strength, int agility) : base(monsterId, partId, name, rank, alligment, price)
        {
            this.Strength = strength;
            this.Agility = agility;
        }

        public override string ToString()
        {
            return "tail";
        }
    }
}
