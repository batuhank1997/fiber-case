namespace _Dev.Game.Scripts.Entities.Projectiles
{
    public class BasicProjectile : Base.Projectile
    {
        protected override int _damageAmount => ProjectileDataContainerSo.Instance.BasicProjectileData.DamageAmount;
    }
}