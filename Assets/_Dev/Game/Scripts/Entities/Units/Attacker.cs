using System;
using System.Collections;
using UnityEngine;

namespace _Dev.Game.Scripts.Entities.Units
{
    [Serializable]
    public abstract class Attacker : Unit
    {
        [SerializeField] protected float m_attackInterval;
        [SerializeField] protected float m_radius;
        
        protected Unit _target;
        
        private readonly WaitForSeconds _detectInterval = new WaitForSeconds(1f);

        protected abstract void Detect();
        protected abstract void Attack(Unit enemy);
        
        protected IEnumerator StartDetectingRoutine()
        {
            while (true)
            {
                Detect();
                yield return _detectInterval;
            }
        }
    }
}