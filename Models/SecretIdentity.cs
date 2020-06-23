using System.Collections.Generic;

namespace APIWithEntity.Models {
    public class SecretIdentity {
        public int Id { get; set; }

        public string RealName { get; set; }
        public Hero Hero { get; set; }
        public int HeroId { get; set; }
    }
}