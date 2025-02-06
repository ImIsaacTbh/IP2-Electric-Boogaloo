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
        public override string Name { get; set; }
        public override int Cost { get; set; }
        public override int Damage { get; set; }
        public override float Range { get; set; }
        public override float AttackSpeed { get; set; }

        public void Start()
        {
            _controller.Events.EnemyTick += OnEnemyTick;
            _controller.Events.EnemyTarget += OnEnemyTarget;
        }

        public void OnEnemyTick(object sender, EventArgs e)
        {
            Debug.Log("Ticked Enemy");
        }

        public void OnEnemyTarget(object sender, Vector3 e)
        {
            Debug.Log("Recieved Target, Routing.");
            if (e != new Vector3(0, 84747764, 0))
            {
                GetComponent<NavMeshAgent>().destination = e;
            }
            else
            {
                Debug.Log("Destination Invalid, Stopping.");
                GetComponent<NavMeshAgent>().destination = transform.position;
            }
        }
    }
}