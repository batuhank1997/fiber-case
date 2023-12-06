using _Dev.Game.Scripts.Components;
using _Dev.Game.Scripts.Entities.Interface;

namespace _Dev.Game.Scripts.Entities.Enemy.Base
{
    public class EnemyBase : Unit, IAttacker
    {
        public int GetAttackInterval { get; }
        public int GetAttackDamage { get; }

        private MoverComponent _mover;

        public void StartAttack()
        {
            
        }

        public void Attack()
        {
        }
    }
}
