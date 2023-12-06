using _Dev.Game.Scripts.Entities.Interface;

namespace _Dev.Game.Scripts.Entities.Turrets.Base
{
    public abstract class Turret : IAttacker
    {
        public abstract float GetAttackInterval { get; }
        public abstract int GetAttackDamage { get; }
        public abstract void Attack();
    }
}