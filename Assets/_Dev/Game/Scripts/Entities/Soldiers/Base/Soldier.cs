using System.Collections;
using _Dev.Game.Scripts.Components;
using _Dev.Game.Scripts.Entities.Enemies.Base;
using _Dev.Game.Scripts.Entities.Units;
using UnityEngine;

namespace _Dev.Game.Scripts.Entities.Soldiers.Base
{
    public abstract class Soldier : Attacker
    {
        [SerializeField] private int m_damage;
        [SerializeField] private float m_attackRadius;
        [SerializeField] private MoverComponent m_mover;
        
        protected override float _attackInterval
        {
            get => m_attackInterval;
            set => _delay = new WaitForSeconds(value);
        }
        
        public void Init()
        {
            _attackInterval = m_attackInterval;
            gameObject.layer = (int)LayerId.Player;
            StartCoroutine(StartDetectingRoutine());
        }

        protected override IEnumerator StartDetectingRoutine()
        {
            while (true)
            {
                yield return _delay;
                SearchEnemy();
            }
        }

        private void SearchEnemy()
        {
            var hitColliders = new Collider[_maxColliders];
            var numColliders = Physics.OverlapSphereNonAlloc(transform.position, m_radius, hitColliders);

            for (var i = 0; i < numColliders; i++)
            {
                if (!hitColliders[i].TryGetComponent(out Unit unit)) continue;
                if (!IsAttackTarget(unit)) continue;

                _target = unit;
                var distance = Vector3.Distance(transform.position, _target.transform.position);

                if (distance < m_attackRadius)
                {
                    m_mover.SetMoveTarget(null);
                    Debug.Log("attack!!");
                    Attack(_target);
                }
                else
                    m_mover.SetMoveTarget(_target.transform);
                
                break;
            }
        }

        protected override void Attack(Unit enemy)
        {
            enemy.GetHealth().Damage(m_damage);
            Debug.Log(enemy.GetHealth());
        }

        protected override bool IsAttackTarget(Unit unit)
        {
            return unit is Enemy;
        }
    }
}