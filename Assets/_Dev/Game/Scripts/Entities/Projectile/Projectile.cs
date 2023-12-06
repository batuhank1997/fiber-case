﻿namespace _Dev.Game.Scripts.Entities.Projectile
{
    public abstract class Projectile
    {
        protected abstract int _damageAmount { get; }
        
        protected Projectile()
        {
        }

        public void DealDamage(Unit unit)
        {
            unit.GetHealth().Damage(_damageAmount);
        }
    }
}