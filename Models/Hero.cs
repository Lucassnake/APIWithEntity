using System;
using System.Collections.Generic;

namespace APIWithEntity.Models {
    public class Hero {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Weapon> Weapons { get; set; }
        public List<BattleHero> BattlesHeros { get; set; }
        public SecretIdentity SecretIdentity { get; set; }
    }
}