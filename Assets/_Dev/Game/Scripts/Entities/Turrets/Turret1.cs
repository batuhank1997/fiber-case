using _Dev.Game.Scripts.Entities.Projectiles;
using _Dev.Game.Scripts.Entities.Turrets.Base;
using _Dev.Game.Scripts.Entities.Units;
using UnityEngine;

namespace _Dev.Game.Scripts.Entities.Turrets
{
    public class Turret1 : Turret
    {
        protected override void Attack(Unit enemy)
        {
            var projectile = Instantiate(m_projectilePrefab, m_projectileSpawnPoint.position, Quaternion.identity);
            projectile.Init(new BasicProjectile(), enemy.transform);
        }
    }
}