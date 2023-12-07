using System.Collections;
using System.Collections.Generic;
using _Dev.Game.Scripts.Entities.Enemies;
using _Dev.Game.Scripts.Entities.Enemies.Base;
using _Dev.Game.Scripts.Entities.PlayerTower;
using _Dev.Game.Scripts.Factories;
using _Dev.Utilities.Singleton;
using UnityEngine;

namespace _Dev.Game.Scripts.Managers
{
    public class WaveManager : Singleton<WaveManager>
    {
        [SerializeField] private List<EnemyWaveSo> m_waves;
        [SerializeField] private Transform m_spawnPoint;
        [SerializeField] private Tower m_waveTarget;
        
        private int _currentWaveIndex;
        private readonly WaitForSeconds _delayBetweenWaves = new WaitForSeconds(3);
        private WaitForSeconds _delayBetweenEnemies;
        
        public void Initialize()
        {
            StartWave();
        }
        
        private void StartWave()
        {
            StartCoroutine(WaveRoutine());
        }
        
        private IEnumerator WaveRoutine()
        {
            var wave = m_waves[_currentWaveIndex];
            var enemies = wave.Enemies;
            var spawnInterval = wave.SpawnInterval;
            _delayBetweenEnemies = new WaitForSeconds(spawnInterval);

            foreach (var enemy in enemies)
            {
                SpawnEnemy(enemy);
                yield return _delayBetweenEnemies;
            }
        }
        
        private void EndWave()
        {
            _currentWaveIndex++;
        }
        
        private void SpawnEnemy(Enemy enemy)
        {
            var createdEnemy = EnemyFactory.Create(enemy);
            createdEnemy.transform.position = m_spawnPoint.position;
            createdEnemy.StartMoving(m_waveTarget.transform);
        }
    }
}
