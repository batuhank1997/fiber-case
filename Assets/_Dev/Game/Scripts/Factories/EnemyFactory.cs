using System.Linq;
using _Dev.Game.Scripts.Entities.Enemies;
using _Dev.Game.Scripts.Entities.Enemies.Base;
using _Dev.Utilities.Singleton;
using UnityEngine;

namespace _Dev.Game.Scripts.Factories
{
    public static class EnemyFactory
    {
        public static EnemyComponent Create<T>() where T : Enemy
        {
            var enemyPrefab = EnemyContainer.Instance.Enemies
                .First(e => e.GetEnemy().GetType() == typeof(T));

            var enemy = Object.Instantiate(enemyPrefab);
        
            return enemy;
        }
    }

    [CreateAssetMenu(fileName = "SoldierContainer", menuName = "ScriptableObjects/SoldierContainer", order = 1)]
    public class EnemyContainer : ScriptableSingleton<EnemyContainer>
    {
        public EnemyComponent[] Enemies;
    }
}