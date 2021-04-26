using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterFightDatabase.Class
{
    class Sponsor
    {
        public string Name { get; set; }
        public int Money { get; set; }
        public int DemandNumber { get; set; }
        

        public Sponsor(string name, int money, int demandNr)
        {
            Name = name;
            Money = money;
            DemandNumber = demandNr;
        }
    }
}
