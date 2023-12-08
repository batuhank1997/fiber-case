using System.Collections;
using _Dev.Game.Scripts.Entities.Enemies.Base;
using _Dev.Game.Scripts.Entities.Units;
using UnityEngine;

namespace _Dev.Game.Scripts.Entities.Enemies
{
    public class RunnerEnemy : Enemy
    {
        [SerializeField] private float m_attackRadius = 1f;
        
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
                    Attack(_target);
                }
                else
                    m_mover.SetMoveTarget(_target.transform);
                
                break;
            }
        }

        protected override void Attack(Unit enemy)
        {
            enemy.GetHealth().Damage(50);
            m_health.OnDie?.Invoke();
        }
    }
}
