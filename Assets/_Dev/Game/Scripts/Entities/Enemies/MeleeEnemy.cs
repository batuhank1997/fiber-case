using _Dev.Game.Scripts.Entities.Enemies.Base;
using _Dev.Game.Scripts.Entities.Units;
using UnityEngine;

namespace _Dev.Game.Scripts.Entities.Enemies
{
    public class MeleeEnemy : Enemy
    {
        [SerializeField] protected int m_attackDamage;

        protected override void Attack(Unit enemy)
        {
            enemy.GetHealth().Damage(m_attackDamage);
        }
    }
}
