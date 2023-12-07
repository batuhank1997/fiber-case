using System.Collections;
using _Dev.Game.Scripts.Entities.Enemies.Base;
using _Dev.Game.Scripts.Entities.Projectiles;
using _Dev.Game.Scripts.Entities.Units;
using UnityEngine;

namespace _Dev.Game.Scripts.Entities.Turrets.Base
{
    public class TurretComponent : Attacker
    {
        [SerializeField] protected ProjectileComponent m_projectilePrefab;
        [SerializeField] protected Transform m_projectileSpawnPoint;
        [SerializeField] private float m_radius;
        
        private Turret _turret;
        
        private readonly WaitForSeconds _detectInterval = new WaitForSeconds(1f);

        private Unit _target;

        public void Init()
        {
            SetTurret(new Turret1());
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
        
        private void SetTurret(Turret turret)
        {
            _turret = turret;
        }

        protected override void Attack(Unit enemy)
        {
            var projectile = Instantiate(m_projectilePrefab, m_projectileSpawnPoint.position, Quaternion.identity);
            projectile.Init(_turret.Projectile, enemy.transform);
        }
    }
}