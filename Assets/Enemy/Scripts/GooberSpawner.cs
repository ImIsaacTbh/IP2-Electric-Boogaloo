using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Enemy.Scripts.EnemyExample;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Enemy.Scripts
{
    public class GooberSpawner : MonoBehaviour
    {
        public static GooberSpawner instance = null;
        private GlobalController _controller;
        public List<GameObject> gooberPrefabs;

        public float _timeSinceLastGooberSpawn = 0f;

        private int shpeeeeed = 0;

        private void Start()
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
        }

        public void Spawn(GameObject gooberPrefab)
        {
            GameObject goober = Instantiate(gooberPrefab, transform.position, Quaternion.identity);
            EnemyController.instance._enemiesInPlay.Add(goober);
        }
    }
}
