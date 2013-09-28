using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class SetBonus
    {
        public string description { get; set; }
        public int threshold { get; set; }
    }

    public class ItemSet
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<SetBonus> setBonuses { get; set; }
        public List<int> items { get; set; }
    }
}
