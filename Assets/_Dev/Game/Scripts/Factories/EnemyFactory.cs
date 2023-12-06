using System.Linq;
using _Dev.Game.Scripts.Entities.Enemies;
using _Dev.Game.Scripts.Entities.Enemies.Base;
using UnityEngine;

namespace _Dev.Game.Scripts.Factories
{
    public static class EnemyFactory
    {
        public static Enemy Create(Enemy enemy)
        {
            var enemyPrefab = EnemyContainerSo.Instance.EnemyPrefabs.First(e => e.GetType() == enemy.GetType());
            var enemyComponent = Object.Instantiate(enemyPrefab);

            return enemyComponent;
        }
    }
}