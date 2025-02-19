using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Enemy.Scripts.EnemyExample
{
    public class EnemyBase : Enemy
    {
        public override string Name { get; set; } = "ExampleEnemy";
        public override float Health { get; set; } = 100;
        public override int Cost { get; set; } = 1;
        public override float Damage { get; set; } = 5;
        public override float Range { get; set; } = 0;
        public override float AttackSpeed { get; set; } = 0;

        private int currentCp = 1;

        public EnemyBase(float healthMult, float damageMult)
        {
            Health *= healthMult;
            Damage = (int)(Damage * damageMult);
        }

        public void Start()
        {
            _controller = GlobalController.instance;
            _controller.Events.EnemyTick += OnEnemyTick;
            _controller.Events.Pause += DoPause;
            //_controller.Events.EnemyTarget += OnEnemyTarget;
            GetComponentInChildren<NavMeshAgent>().enabled = true;
            GetComponentInChildren<NavMeshAgent>().destination = MapHandler.instance._checkpointList[0].transform.position;
        }

        public void DoPause(object sender, EventArgs e)
        {

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
                    GetComponentInChildren<NavMeshAgent>().destination = other.transform.parent
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