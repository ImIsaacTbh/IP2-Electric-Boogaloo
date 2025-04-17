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
        public GameObject globalUpgradesButtons;

        public List<Wave> waves = new List<Wave>();
        
        public Wave currentWave;
        public float ticksSinceLastSpawn;
        private int enemiesSpawned;
        private int currentEnemyTypeIndex;
        private int currentEnemyCount;

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(this.gameObject);
            }

            _controller = GlobalController.instance;

            waves = new List<Wave>
            {
                new Wave(new List<EnemyBunch>()
                {
                    new EnemyBunch
                    {
                        enemyPrefab = enemyPrefabs[0],
                        count = 4
                    },
                }, 1.5f),
                new Wave(new List<EnemyBunch>()
                {
                    new EnemyBunch
                    {
                        enemyPrefab = enemyPrefabs[1],
                        count = 1
                    },
                    new EnemyBunch
                    {
                        enemyPrefab = enemyPrefabs[0],
                        count = 4
                    }
                }, 1.5f),
                new Wave(new List<EnemyBunch>()
                {
                    new EnemyBunch
                    {
                        enemyPrefab = enemyPrefabs[1],
                        count = 8
                    }
                }, 2f),
                new Wave(new List<EnemyBunch>()
                {
                    new EnemyBunch
                    {
                        enemyPrefab = enemyPrefabs[0],
                        count = 16
                    }
                }, 1f),
                new Wave(new List<EnemyBunch>()
                {
                    new EnemyBunch
                    {
                        enemyPrefab = enemyPrefabs[1],
                        count = 4
                    },
                    new EnemyBunch
                    {
                        enemyPrefab = enemyPrefabs[0],
                        count = 8
                    }
                }, 1f),
                new Wave(new List<EnemyBunch>()
                {
                    new EnemyBunch
                    {
                        enemyPrefab = enemyPrefabs[1],
                        count = 8
                    },
                    new EnemyBunch
                    {
                        enemyPrefab = enemyPrefabs[0],
                        count = 16
                    }
                }, 1f),
                new Wave(new List<EnemyBunch>()
                {
                    new EnemyBunch
                    {
                        enemyPrefab = enemyPrefabs[1],
                        count = 16
                    },
                    new EnemyBunch
                    {
                        enemyPrefab = enemyPrefabs[0],
                        count = 32
                    }
                }, 1f),
                new Wave(new List<EnemyBunch>()
                {
                    new EnemyBunch
                    {
                        enemyPrefab = enemyPrefabs[1],
                        count = 32
                    },
                    new EnemyBunch
                    {
                        enemyPrefab = enemyPrefabs[0],
                        count = 64
                    }
                }, 1f),
                
            };


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
        }

        public IEnumerator spawnGoobers()
        {
            foreach (EnemyBunch b in currentWave.enemyBunches)
            {
                for (int i = 0; i < b.count; i++)
                {
                    GooberSpawner.instance.Spawn(b.enemyPrefab);
                    yield return new WaitForSeconds(currentWave.spawnInterval);
                }
            }
        }
        
        private void StartWave()
        {
            _controller._isWaveInProgress = true;
            ticksSinceLastSpawn = float.MaxValue;
            currentWave = waves[_controller._waveNumber];
            StartCoroutine(spawnGoobers());
        }
        
        public void SkipWave()
        {
            _controller.Events.SendResetWave(null);
            currentWave = null;
            _controller._isWaveInProgress = false;
            _controller._waveNumber++;
        }
    }
}