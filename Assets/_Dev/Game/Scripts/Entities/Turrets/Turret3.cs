using _Dev.Game.Scripts.Entities.Projectiles;

namespace _Dev.Game.Scripts.Entities.Turrets
{
    public class Turret3 : Turret
    {
        public override TurretData TurretData => TurretDataContainerSo.Instance.Turret3Data;
        public override Projectiles.Base.Projectile Projectile => new ExplosiveProjectile();
    }
}