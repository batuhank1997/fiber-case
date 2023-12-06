using _Dev.Game.Scripts.Components;
using _Dev.Game.Scripts.Entities.Interface;

namespace _Dev.Game.Scripts.Entities.Enemies.Base
{
    public abstract class Enemy : IAttacker
    {
        public float GetAttackInterval { get; }
        public int GetAttackDamage { get; }

        private MoverComponent _mover;

        public abstract void Attack();
    }
}
