using APIWithEntity.Models;
using Microsoft.EntityFrameworkCore;

namespace APIWithEntity.Data {
    public class HeroContext : DbContext {
        public DbSet<Hero> Heros { get; set; }
        public DbSet<Battle> Battles { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
       

        public DbSet<BattleHero> BattleHeroes { get; set; }
        public DbSet<SecretIdentity> SecretIdentities { get; set; }
        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer ("Password=SqlServer2017!;Persist Security Info=True;User ID=SA;Initial Catalog=HeroApp;Data Source=localhost,1433");
        }
        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            modelBuilder.Entity<BattleHero> (entity => {
                entity.HasKey (e => new { e.BattleId, e.HeroId });
            });
        }
    }

}