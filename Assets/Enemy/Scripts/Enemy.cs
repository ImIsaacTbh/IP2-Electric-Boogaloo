using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Enemy.Scripts
{
    public abstract class Enemy : MonoBehaviour
    {
        public GlobalController _controller = GlobalController.instance;

        public abstract string Name { get; set; }
        public abstract int Cost { get; set; }
        public abstract float Health { get; set; }
        public abstract float Damage { get; set; }
        public abstract float Range { get; set; }
        public abstract float AttackSpeed { get; set; }


        public void Start()
        {
            _controller.Events.EnemyTick += OnEnemyTick;
        }

        public void OnEnemyTick(object sender, EventArgs e)
        {
            
        }

        private void OnTriggerEnter(Collider other)
        {
            print("Entered trigger");
            if (other.gameObject.CompareTag("Checkpoint"))
            {
                print("Got to checkpoint");
                try
                {
                    GetComponentInChildren<NavMeshAgent>().destination = other.transform.parent
                        .GetChild(int.Parse(other.gameObject.name)).transform.position;
                }
                catch
                {
                    Debug.LogWarning("Something brokeded lmao");
                }
            }
            if (other.CompareTag("EnemyKillVolume"))
            {

                Destroy(this.gameObject);
                Console.WriteLine("test");

                _controller.Events.SendEnemyCompletedPath(Cost);
            }
        }
    }
}