using _Dev.Game.Scripts.Entities.Projectiles;

namespace _Dev.Game.Scripts.Entities.Projectile
{
    public class HeavyProjectile : Projectiles.Base.Projectile
    {
        protected override int _damageAmount => ProjectileDataContainerSo.Instance.HeavyProjectileData.DamageAmount;
    }
}