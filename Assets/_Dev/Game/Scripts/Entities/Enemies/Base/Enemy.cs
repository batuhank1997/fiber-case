using _Dev.Game.Scripts.Components;
using _Dev.Game.Scripts.Entities.PlayerTower;
using _Dev.Game.Scripts.Entities.Soldiers.Base;
using _Dev.Game.Scripts.Entities.Units;
using _Dev.Game.Scripts.EventSystem;
using _Dev.Game.Scripts.Managers;
using UnityEngine;

namespace _Dev.Game.Scripts.Entities.Enemies.Base
{
    [RequireComponent(typeof(MoverComponent))]
    public abstract class Enemy : Attacker
    {
        [SerializeField] protected MoverComponent m_mover;
        
        protected Transform _mainTarget;
        
        protected override float _attackInterval
        {
            get => m_attackInterval;
            set => _delay = new WaitForSeconds(value);
        }

        public void Init(Transform tower)
        {
            _mainTarget = tower;
            StartMoving(_mainTarget);
            _attackInterval = m_attackInterval;
            gameObject.layer = (int)LayerId.Enemy;
            m_health.OnDie += OnEnemyDie;
            StartCoroutine(StartDetectingRoutine());
        }

        private void OnDisable()
        {
            m_health.OnDie -= OnEnemyDie;
        }

        private void OnEnemyDie()
        {
            EventSystemManager.InvokeEvent(EventId.on_enemy_died);
            ResourcesManager.AddResource(100);
        }

        protected void StartMoving(Transform target)
        {
            m_mover.SetMoveTarget(target);
        }
        
        protected void StopMoving()
        {
            m_mover.SetMoveTarget(null);
        }

        protected override bool IsAttackTarget(Unit unit)
        {
            return unit is Tower or Soldier;
        }
    }
}
