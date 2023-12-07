using _Dev.Game.Scripts.Entities.Projectile;

namespace _Dev.Game.Scripts.Entities.Turrets
{
    public class Turret2 : Turret
    {
        public override Projectiles.Base.Projectile Projectile => new HeavyProjectile();
    }
}