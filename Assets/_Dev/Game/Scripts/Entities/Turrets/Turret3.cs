using _Dev.Game.Scripts.Entities.Projectiles;

namespace _Dev.Game.Scripts.Entities.Turrets
{
    public class Turret3 : Turret
    {
        public override TurretData TurretData { get; }
        public override float AttackInterval => 0.5f;
        public override Projectiles.Base.Projectile Projectile => new ExplosiveProjectile();
        
        public Turret3()
        {
            TurretData = new TurretData
            {
                Name = "Turret 3",
                Level = 3,
                TurretPrice = 500
            };
        }
    }
}