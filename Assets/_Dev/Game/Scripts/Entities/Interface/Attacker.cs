using System;
using System.Collections;
using UnityEngine;

namespace _Dev.Game.Scripts.Entities.Interface
{
    [Serializable]
    public abstract class Attacker : MonoBehaviour
    {
        [SerializeField] protected float m_attackInterval;
        [SerializeField] protected int m_attackDamage;
        
        protected abstract void Attack();
        public IEnumerator StartAttackRoutine()
        {
            while (true)
            {
                Attack();
                yield return new WaitForSeconds(m_attackInterval);
            }
        }
    }
}