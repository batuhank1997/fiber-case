using System;
using System.Collections;
using System.Collections.Generic;
using _Dev.Game.Scripts.Entities.Enemies;
using _Dev.Game.Scripts.Entities.Enemies.Base;
using _Dev.Game.Scripts.Entities.PlayerTower;
using _Dev.Game.Scripts.EventSystem;
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
        
        private readonly List<Enemy> _currentWaveEnemies = new List<Enemy>();
        private readonly WaitForSeconds _delayBetweenWaves = new WaitForSeconds(3);
        private WaitForSeconds _delayBetweenEnemies;
        private int _currentWaveIndex;
        private int _killedEnemiesCountInCurrentWave = 0;
        
        public void Initialize()
        {
            EventSystemManager.AddListener(EventId.on_enemy_died, OnEnemyDied);
            EventSystemManager.AddListener(EventId.on_wave_ended, ResetWaveData);
            StartWave();
        }

        private void OnDestroy()
        {
            EventSystemManager.RemoveListener(EventId.on_enemy_died, OnEnemyDied);
            EventSystemManager.RemoveListener(EventId.on_wave_ended, ResetWaveData);
        }

        private void OnEnemyDied(EventArgs obj)
        {
            _killedEnemiesCountInCurrentWave++;

            if (_killedEnemiesCountInCurrentWave != GetCurrentWaveEnemiesCount()) 
                return;
            
            EndWave();
            StartWave();
        }
        
        private void ResetWaveData(EventArgs obj)
        {
            _killedEnemiesCountInCurrentWave = 0;
            _currentWaveEnemies.Clear();
        }

        public float GetWaveProgress()
        {
            return (float)_killedEnemiesCountInCurrentWave / (float)GetCurrentWaveEnemiesCount();
        }
        
        private void StartWave()
        {
            EventSystemManager.InvokeEvent(EventId.on_wave_started);
            StartCoroutine(WaveRoutine());
        }
        
        private IEnumerator WaveRoutine()
        {
            yield return _delayBetweenWaves;
            
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
            EventSystemManager.InvokeEvent(EventId.on_wave_ended);
            _currentWaveIndex++;
        }
        
        private void SpawnEnemy(Enemy enemy)
        {
            var createdEnemy = EnemyFactory.Create(enemy);
            _currentWaveEnemies.Add(createdEnemy);
            createdEnemy.transform.position = m_spawnPoint.position;
            createdEnemy.StartMoving(m_waveTarget.transform);
        }

        private int GetCurrentWaveEnemiesCount()
        {
            if (_currentWaveIndex > m_waves.Count - 1)
                _currentWaveIndex = 0;
            
            var wave = m_waves[_currentWaveIndex];
            return wave.Enemies.Count;
        }

        public int GetTotalWaveCount()
        {
            return m_waves.Count;
        }

        public int GetCurrentWaveIndex()
        {
            return _currentWaveIndex + 1;
        }
    }
}
