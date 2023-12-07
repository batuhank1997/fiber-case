using System;

namespace _Dev.Game.Scripts.Entities.Turrets
{
    public abstract class Turret
    {
        public float AttackInterval => TurretData.AttackInterval;
        public abstract TurretData TurretData { get; }
        public abstract Projectiles.Base.Projectile Projectile { get; }
        
        public Turret Upgrade()
        {
            return TurretData.Level switch
            {
                1 => new Turret2(),
                2 => new Turret3(),
                3 => new Turret3(),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}