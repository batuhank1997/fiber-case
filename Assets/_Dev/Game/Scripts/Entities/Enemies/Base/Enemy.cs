using System.Resources;
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
        [SerializeField] private MoverComponent m_mover;

        private void OnEnable()
        {
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

        public void StartMoving(Transform target)
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
