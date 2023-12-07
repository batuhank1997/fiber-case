using System;
using System.Collections;
using UnityEngine;

namespace _Dev.Game.Scripts.Entities.Units
{
    [Serializable]
    public abstract class Attacker : Unit
    {
        [SerializeField] protected float m_attackInterval;
        [SerializeField] protected int m_attackDamage;
        
        protected abstract void Attack(Unit enemy);
        public IEnumerator StartAttackRoutine(Unit enemy)
        {
            while (true)
            {
                Attack(enemy);
                yield return new WaitForSeconds(m_attackInterval);
            }
        }
    }
}