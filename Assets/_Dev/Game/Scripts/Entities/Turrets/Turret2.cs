using _Dev.Game.Scripts.Entities.Projectile;
using _Dev.Game.Scripts.Entities.Turrets.Base;
using _Dev.Game.Scripts.Entities.Units;
using UnityEngine;

namespace _Dev.Game.Scripts.Entities.Turrets
{
    public class Turret2 : Turret
    {
        protected override void Attack(Unit enemy)
        {
            var projectile = Instantiate(m_projectilePrefab, transform.position, Quaternion.identity);
            projectile.Init(new HeavyProjectile(), enemy.transform);
        }
    }
}