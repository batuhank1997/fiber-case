using System;
using _Dev.Game.Scripts.Components;
using _Dev.Game.Scripts.Entities.PlayerTower;
using _Dev.Game.Scripts.Entities.Soldiers.Base;
using _Dev.Game.Scripts.Entities.Units;
using UnityEngine;

namespace _Dev.Game.Scripts.Entities.Enemies.Base
{
    [RequireComponent(typeof(MoverComponent))]
    public abstract class Enemy : Attacker
    {
        [SerializeField] private MoverComponent m_mover;
        
        private const int _maxColliders = 10;

        private void OnEnable()
        {
            StartCoroutine(StartDetectingRoutine());
        }

        public void StartMoving(Transform target)
        {
            m_mover.SetMoveTarget(target);
        }
        
        protected void StopMoving()
        {
            m_mover.SetMoveTarget(null);
        }
        
        protected override void Detect()
        {
            var hitColliders = new Collider[_maxColliders];
            var numColliders = Physics.OverlapSphereNonAlloc(transform.position, m_radius, hitColliders);
            
            for (var i = 0; i < numColliders; i++)
            {
                var col = hitColliders[i];

                if (!col.TryGetComponent(out Unit unit)) continue;

                if (unit is not Tower && unit is not Soldier) continue;
                
                _target = unit;
                Attack(_target);
            }
        }
    }
}
