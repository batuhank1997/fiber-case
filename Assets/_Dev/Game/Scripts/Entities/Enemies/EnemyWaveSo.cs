using System.Collections.Generic;
using _Dev.Game.Scripts.Entities.Enemies.Base;
using UnityEngine;

namespace _Dev.Game.Scripts.Entities.Enemies
{
    [CreateAssetMenu(fileName = "EnemyWaveSo", menuName = "ScriptableObjects/EnemyWaveSo")]
    public class EnemyWaveSo : ScriptableObject
    {
        [SerializeReference] public List<Enemy> Enemies;
        public float SpawnInterval;
    }
}