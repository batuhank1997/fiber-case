using _Dev.Game.Scripts.Entities.Projectiles;

namespace _Dev.Game.Scripts.Entities.Turrets
{
    public class Turret1 : Turret
    {
        public override TurretData TurretData => TurretDataContainerSo.Instance.Turret1Data;
        public override float AttackInterval => 1f;
        public override Projectiles.Base.Projectile Projectile => new BasicProjectile();
    }
}