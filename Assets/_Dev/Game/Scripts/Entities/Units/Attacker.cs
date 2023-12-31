﻿using System;
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
        protected WaitForSeconds _delay;
        protected abstract float _attackInterval { get; set; }

        protected const int _maxColliders = 10;
        
        protected abstract void Attack(Unit enemy);
        protected abstract bool IsAttackTarget(Unit unit);
        
        protected virtual IEnumerator StartDetectingRoutine()
        {
            while (true)
            {
                Detect();
                yield return _delay;
            }
        }
        
        private void Detect()
        {
            var hitColliders = new Collider[_maxColliders];
            var numColliders = Physics.OverlapSphereNonAlloc(transform.position, m_radius, hitColliders);
            
            for (var i = 0; i < numColliders; i++)
            {
                if (!hitColliders[i].TryGetComponent(out Unit unit)) continue;

                if (!IsAttackTarget(unit)) continue;
                
                _target = unit;
                Attack(_target);
                break;
            }
        }
    }
}