using _Dev.Game.Scripts.Entities.Projectile;

namespace _Dev.Game.Scripts.Entities.Turrets
{
    public class Turret2 : Turret
    {
        public override TurretData TurretData { get; }
        public override Projectiles.Base.Projectile Projectile => new HeavyProjectile();
        
        public Turret2()
        {
            TurretData = new TurretData
            {
                Name = "Turret 2",
                Level = 2,
                TurretPrice = 300
            };
        }
    }
}