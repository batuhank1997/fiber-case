using _Dev.Game.Scripts.Entities.Projectile;

namespace _Dev.Game.Scripts.Entities.Turrets
{
    public class Turret2 : Turret
    {
        public override TurretData TurretData  => TurretDataContainerSo.Instance.Turret2Data;
        public override float AttackInterval => 0.75f;
        public override Projectiles.Base.Projectile Projectile => new HeavyProjectile();
    }
}