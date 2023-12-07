using _Dev.Game.Scripts.Entities.Enemies.Base;
using _Dev.Game.Scripts.Entities.Projectiles;
using _Dev.Game.Scripts.Entities.Units;
using UnityEngine;

namespace _Dev.Game.Scripts.Entities.Enemies
{
    public class RangedEnemy : Enemy
    {
        [SerializeField] private ProjectileComponent m_projectilePrefab;
        [SerializeField] private Transform m_projectileSpawnPoint;

        protected override void Attack(Unit enemy)
        {
            StopMoving();
            var projectile = Instantiate(m_projectilePrefab, m_projectileSpawnPoint.position, Quaternion.identity);
            projectile.Init(new BasicProjectile(), enemy.transform);
            
            enemy.GetHealth().OnDie += () =>
            {
                if (projectile)
                    Destroy(projectile.gameObject);
            };
        }
    }
}
