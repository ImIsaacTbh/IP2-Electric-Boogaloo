using System;
using System.Collections;
using Assets.Enemy.Scripts;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Enemy.Scripts
{
    public class EnemyBunch
    {
        public GameObject enemyPrefab;
        public int count;
    }

    public class Wave
    {
        public List<EnemyBunch> enemyBunches;
        public float spawnInterval;

        public Wave(List<EnemyBunch> bunches, float interval)
        {
            enemyBunches = bunches;
            spawnInterval = interval;
        }
    }

    public class WaveManager : MonoBehaviour
    {
        public GlobalController _controller;
        public static WaveManager instance = null;
        public List<GameObject> enemyPrefabs;

        [Header("Initial Wave Settings")]
        public int minEnemiesPerWave = 5;
        public int maxEnemiesPerWave = 20;
        public float spawnInterval = 3f;

        public Wave currentWave;
        public float ticksSinceLastSpawn;
        private int enemiesSpawned;
        private int currentEnemyTypeIndex;
        private int currentEnemyCount;

        void Awake()
        {
            if(instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(this.gameObject);
            }
            _controller = GlobalController.instance;
            _controller.Events.TryStartWave += (object sender, EventArgs e) =>
            {
                print("recieved attempted wave start");
                if(!_controller._isWaveInProgress) StartWave();
            };
            _controller.Events.EnemyTick += EnemyTick;
        }

        public void EnemyTick(object sender, EventArgs e)
        {
            if (!_controller._isWaveInProgress) return;
            ticksSinceLastSpawn++;
            if (ticksSinceLastSpawn > currentWave.spawnInterval *50)
            {
                try
                {
                    EnemyBunch bunch = currentWave.enemyBunches.First();
                    for (int i = 0; i < bunch.count; i++)
                    {
                        GooberSpawner.instance.Spawn(bunch.enemyPrefab);
                        currentWave.enemyBunches.Remove(bunch);
                    }
                }
                catch
                {
                }

                ticksSinceLastSpawn = 0;
            }
        }

        private void StartWave()
        {
            GenerateRandomWave(_controller._waveNumber);
            _controller._isWaveInProgress = true;
            ticksSinceLastSpawn = float.MaxValue;
        }

        void GenerateRandomWave(int waveNumber)
        {
            List<EnemyBunch> enemies = new List<EnemyBunch>();
            int enemyCount = Random.Range(minEnemiesPerWave, maxEnemiesPerWave);
            int addedCount = 0;
            for (int i = 0; i < enemyCount; i++)
            {
                GameObject randomEnemyPrefab = enemyPrefabs.PickRandom();
                for (int j = 0; j < enemyCount - addedCount; j++)
                {
                    //int amount = 1;
                    int amount = waveNumber > 10 ? Random.Range(1, enemyCount - addedCount + 1) : 1;
                    addedCount += amount;
                    enemies.Add(new EnemyBunch { count = amount, enemyPrefab = randomEnemyPrefab });
                }
            }

            // Exponentially increase the enemy count based on the wave number
            int exponentialFactor = (int)Mathf.Pow(2, waveNumber);
            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].count *= exponentialFactor;
            }
            spawnInterval -= 0.05f * waveNumber < 0.25 ? 0.05f * waveNumber : 0.25f;
            currentWave = new Wave(enemies, spawnInterval);
        }

        public void SkipWave()
        {
            currentWave = null;
            EnemyController.instance.KillAllEnemies();
            _controller._isWaveInProgress = false;
            _controller._waveNumber++;
        }
    }
}