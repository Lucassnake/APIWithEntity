using System;
using System.Collections.Generic;

namespace APIWithEntity.Models {
    public class Battle {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DtStart { get; set; }
        public DateTime DtEnde { get; set; }
        public List<BattleHero> BattlesHeros { get; set; }
    }
}