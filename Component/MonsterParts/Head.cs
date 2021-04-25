using MonsterFightDatabase.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterFightDatabase.Component.MonsterParts
{
    public class Head : MonsterPart
    {
        public int Defence { get; set; }
        public int Agility { get; set; }
        public Head(int monsterId, int partId, string name, string rank, string alligment, int price, int defence, int agility) : base(monsterId, partId, name, rank, alligment, price)
        {
            this.Defence = defence;
            this.Agility = agility;
        }

        public override string ToString()
        {
            return "head";
        }
    }
}
