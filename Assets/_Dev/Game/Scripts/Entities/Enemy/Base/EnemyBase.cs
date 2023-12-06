using System.Collections;
using _Dev.Game.Scripts.Components;
using _Dev.Game.Scripts.Entities.Interface;
using UnityEngine;

namespace _Dev.Game.Scripts.Entities.Enemy.Base
{
    public abstract class EnemyBase : Unit, IAttacker
    {
        public int GetAttackInterval { get; }
        public int GetAttackDamage { get; }

        private MoverComponent _mover;

        public IEnumerator StartAttackRoutine()
        {
            while (true)
            {
                Attack();
                yield return new WaitForSeconds(GetAttackInterval);
            }
        }

        public abstract void Attack();
    }
}
