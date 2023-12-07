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
        
        private Turret _turret;
        
        private const int _maxColliders = 10;
        
        public void Init()
        {
            SetTurret(new Turret1());
            StartCoroutine(StartDetectingRoutine());
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
        
        protected override void Detect()
        {
            var hitColliders = new Collider[_maxColliders];
            var size = Physics.OverlapSphereNonAlloc(transform.position, m_radius, hitColliders);

            for (var i = 0; i < size; i++)
            {
                if (!hitColliders[i].TryGetComponent(out Enemy enemy)) continue;
                
                _target = enemy;
                Attack(_target);
            }
        }
    }
}