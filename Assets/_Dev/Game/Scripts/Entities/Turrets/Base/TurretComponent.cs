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
        
        protected override bool IsAttackTarget(Unit unit)
        {
           return unit is Enemy;
        }
    }
}