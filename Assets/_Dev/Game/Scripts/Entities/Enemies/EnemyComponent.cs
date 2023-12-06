using _Dev.Game.Scripts.Entities.Enemies.Base;
using UnityEngine;

namespace _Dev.Game.Scripts.Entities.Enemies
{
    public class EnemyComponent : MonoBehaviour
    {
        private readonly Enemy _enemy = new MeleeEnemy();

        public Enemy GetEnemy()
        {
            return _enemy;
        }
    }
}