using _Dev.Game.Scripts.Entities.Enemies.Base;
using _Dev.Game.Scripts.Entities.Projectiles;
using UnityEngine;

namespace _Dev.Game.Scripts.Entities.Enemies
{
    public class RangedEnemy : Enemy
    {
        [SerializeField] private ProjectileComponent m_projectilePrefab;
        
        public override void Attack()
        {
            
        }
    }
}
