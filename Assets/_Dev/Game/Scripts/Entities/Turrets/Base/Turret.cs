using System.Collections;
using _Dev.Game.Scripts.Entities.Enemies.Base;
using _Dev.Game.Scripts.Entities.Projectiles;
using _Dev.Game.Scripts.Entities.Units;
using UnityEngine;

namespace _Dev.Game.Scripts.Entities.Turrets.Base
{
    public abstract class Turret : Attacker
    {
        [SerializeField] protected ProjectileComponent m_projectilePrefab;
        [SerializeField] protected Transform m_projectileSpawnPoint;
        [SerializeField] private float m_radius;
        
        private readonly WaitForSeconds _detectInterval = new WaitForSeconds(1f);

        private Unit _target;

        public void Init()
        {
            StartCoroutine(StartDetectingRoutine());
        }
        
        private IEnumerator StartDetectingRoutine()
        {
            while (true)
            {
                Detect();
                yield return _detectInterval;
            }
        }

        private void Detect()
        {
            var colliders = Physics.OverlapSphere(transform.position, m_radius);

            if (!colliders[0].TryGetComponent(out Unit unit)) return;
            if (unit is not Enemy) return;

            _target = unit;
            Attack(_target);
        }

        protected abstract override void Attack(Unit enemy);
    }
}