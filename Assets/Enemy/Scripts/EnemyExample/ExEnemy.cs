using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Enemy.Scripts.EnemyExample
{
    public class ExEnemy : Enemy
    {
        public override string Name { get; set; } = "ExampleEnemy";
        public override int Cost { get; set; } = 1;
        public override int Damage { get; set; } = 5;
        public override float Range { get; set; } = 0;
        public override float AttackSpeed { get; set; } = 0;

        private int currentCp = 1;

        public void Start()
        {
            _controller = GlobalController.instance;
            _controller.Events.EnemyTick += OnEnemyTick;
            //_controller.Events.EnemyTarget += OnEnemyTarget;
            GetComponent<NavMeshAgent>().enabled = true;
            GetComponent<NavMeshAgent>().destination = MapHandler.instance._checkpointList[0].transform.position;
        }
        
        public void OnEnemyTick(object sender, EventArgs e)
        {
            Debug.Log("Ticked Enemy");
        }

        // public void OnEnemyTarget(object sender, Vector3 e)
        // {
        //     Debug.Log("Recieved Target, Routing.");
        //     if (e != new Vector3(0, 84747764, 0))
        //     {
        //         GetComponent<NavMeshAgent>().destination = e;
        //     }
        //     else
        //     {
        //         Debug.Log("Destination Invalid, Stopping.");
        //         GetComponent<NavMeshAgent>().destination = transform.position;
        //     }
        // }

        public void OnTriggerEnter(Collider other)
        {
            
            if (other.gameObject.CompareTag("Checkpoint"))
            {
                try
                {
                    GetComponent<NavMeshAgent>().destination = other.transform.parent
                        .GetChild(int.Parse(other.gameObject.name)).transform.position;
                }
                catch {
                    Debug.LogWarning("Something brokeded lmao");
                }
            }
            base.OnTriggerEnter(other);

        }
    }
}