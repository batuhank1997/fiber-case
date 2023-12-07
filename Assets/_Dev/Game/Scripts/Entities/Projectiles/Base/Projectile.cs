using _Dev.Game.Scripts.Entities.Units;

namespace _Dev.Game.Scripts.Entities.Projectiles.Base
{
    public abstract class Projectile
    {
        protected abstract int _damageAmount { get; }
   
        public virtual void DealDamage(Unit unit)
        {
            unit.GetHealth().Damage(_damageAmount);
        }
    }
}