using _Dev.Game.Scripts.Entities.Enemy.Base;
using _Dev.Game.Scripts.Entities.Projectile;
using UnityEngine;

namespace _Dev.Game.Scripts.Entities.Enemy
{
    public class RangedEnemy : EnemyBase
    {
        [SerializeField] private ProjectileComponent m_projectilePrefab;
        public override void Attack()
        {
            
        }
    }
}
