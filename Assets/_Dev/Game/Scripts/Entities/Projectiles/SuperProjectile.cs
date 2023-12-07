namespace _Dev.Game.Scripts.Entities.Projectiles
{
    public class SuperProjectile : Projectiles.Base.Projectile
    {
        protected override int _damageAmount => ProjectileDataContainerSo.Instance.SuperProjectileData.DamageAmount;
    }
}