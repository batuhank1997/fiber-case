using _Dev.Game.Scripts.Entities.Projectiles;

namespace _Dev.Game.Scripts.Entities.Turrets
{
    public class Turret1 : Turret
    {
        public override TurretData TurretData { get; }
        public override Projectiles.Base.Projectile Projectile => new BasicProjectile();
        
        public Turret1()
        {
            TurretData = new TurretData
            {
                Name = "Turret 1",
                Level = 1,
                TurretPrice = 100
            };
        }
    }
}