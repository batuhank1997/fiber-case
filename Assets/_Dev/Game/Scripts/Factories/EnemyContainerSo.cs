using System.Collections.Generic;
using _Dev.Game.Scripts.Entities.Enemies;
using _Dev.Game.Scripts.Entities.Enemies.Base;
using _Dev.Utilities.Singleton;
using UnityEngine;

namespace _Dev.Game.Scripts.Factories
{
    [CreateAssetMenu(fileName = "EnemyContainerSo", menuName = "ScriptableObjects/EnemyContainerSo", order = 1)]
    public class EnemyContainerSo : ScriptableSingleton<EnemyContainerSo>
    {
        public List<Enemy> EnemyPrefabs;
    }
}