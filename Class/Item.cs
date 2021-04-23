using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterFightDatabase.Class
{
    public class Item
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Legal { get; set; }
        public int EffctNumber { get; set; }
        public int MonsterID { get; set; }


        public Item(string name, int price, int legal, int effectNumber)
        {
            Name = name;
            Price = price;
            Legal = legal;
            EffctNumber = effectNumber;
        }


    }
}
