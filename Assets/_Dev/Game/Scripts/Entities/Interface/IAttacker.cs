using System.Collections;
using UnityEngine;

namespace _Dev.Game.Scripts.Entities.Interface
{
    public interface IAttacker
    {
        int GetAttackInterval { get; }
        int GetAttackDamage { get; }
        void Attack();
        public IEnumerator StartAttackRoutine()
        {
            while (true)
            {
                Attack();
                yield return new WaitForSeconds(GetAttackInterval);
            }
        }
    }
}