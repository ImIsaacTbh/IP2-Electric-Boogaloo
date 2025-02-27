using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
    public class EnemyController : MonoBehaviour
    {
        public GlobalController _controller;
        public static EnemyController instance = null;
        public List<GameObject> _enemiesInPlay = new List<GameObject>();
        public float _timeSinceLastEnemyTick = 0f;
        public float _timeSinceLastEnemySpawn = 0f;

        void Awake()
        {
            _controller = GlobalController.instance;
            if(instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
            _controller.Events.CentralTick += OnCentralTick;
        }

        public void OnCentralTick(object sender, EventArgs e)
        {
            //Debug.Log("Recieved Event");
            _timeSinceLastEnemyTick += Time.deltaTime;
            if (_controller.IsWaveInProgress() && _timeSinceLastEnemyTick > 1/_controller._towerTickRate)
            {
                _controller.Events.SendEnemyTick(EventArgs.Empty);
            }
            if(_enemiesInPlay.Count <= 0 && _controller.IsWaveInProgress())
            {
                _controller._waveNumber++;
                _controller._isWaveInProgress = false;
            }
        }

        void Start()
        {
            
            _controller.Events.CentralTick += OnCentralTick;
            Debug.Log("Started EnemyController");
        }

        void Update()
        {
            for(int i = 0; i < _enemiesInPlay.Count; i++)
            {
                if(_enemiesInPlay[i] == null)
                {
                    _enemiesInPlay.RemoveAt(i);
                }
            }
        }

        public void KillAllEnemies()
        {
            foreach(GameObject enemy in _enemiesInPlay)
            {
                Destroy(enemy);
            }
            _enemiesInPlay.Clear();
        }
    }
}
