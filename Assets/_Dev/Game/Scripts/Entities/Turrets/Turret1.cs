using _Dev.Game.Scripts.Entities.Projectiles;

namespace _Dev.Game.Scripts.Entities.Turrets
{
    public class Turret1 : Turret
    {
        public override Projectiles.Base.Projectile Projectile => new BasicProjectile();
    }
}