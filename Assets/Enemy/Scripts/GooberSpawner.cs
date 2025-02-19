using Assets.Enemy.Scripts.EnemyExample;
using UnityEngine;

namespace Assets.Enemy.Scripts
{
    public class GooberSpawner : MonoBehaviour
    {
        private GlobalController _controller;
        public GameObject gooberPrefab;

        public float _timeSinceLastGooberSpawn = 0f;

        private int shpeeeeed = 0;

        private void Start()
        {
            _controller = GlobalController.instance;
            _controller.Events.CentralTick += CentralTick;
            _controller.Events.SpawnEnemy += SpawnEnemy;
        }

        private void CentralTick(object sender, System.EventArgs e)
        {
            _timeSinceLastGooberSpawn += Time.deltaTime;
            if (Mathf.Pow(_controller._wavecoefficient, _controller._waveexponent) < _timeSinceLastGooberSpawn)
            {
                _controller.Events.SendSpawnEnemy(new EventData.EnemySpawnArgs(5, _controller._waveexponent, _controller._waveexponent));
                _timeSinceLastGooberSpawn = 0;
            }
        }

        private void SpawnEnemy(object sender, EventData.EnemySpawnArgs args)
        {
            for (int i = 0; i < args.enemyCount; i++)
            {
                var goober = Instantiate(gooberPrefab);
                goober.transform.position = transform.position;
                goober.AddComponent<EnemyBase>().Health *= args.healthModifier;
                goober.GetComponent<EnemyBase>().Damage *= args.damageModifier;
            }
        }
    }
}
