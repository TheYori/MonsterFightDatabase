using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterFightDatabase.Class
{
    public abstract class MonsterPart : Component
    {
        public int MonsterId { get; set; }
        public int PartId { get; set; }
        public string Name { get; set; }
        public string Rank { get; set; }
        public string Alligment { get; set; }
        public int Price { get; set; }
        public MonsterPart(int monsterId, int partId, string name, string rank, string alligment, int price)
        {
            this.MonsterId = monsterId;
            this.PartId = partId;
            this.Name = name;
            this.Rank = rank;
            this.Alligment = alligment;
            this.Price = price;
        }
    }
}
