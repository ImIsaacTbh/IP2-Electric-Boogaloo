using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Enemy.Scripts.EnemyExample
{
    public class Mantis : Enemy
    {
        public override string Name { get; set; } = "Mantis";
        public override float Health { get; set; } = 125f;
        public override int Cost { get; set; } = 10;
        public override float Damage { get; set; } = 5;
        public override float Range { get; set; } = 0;
        public override float AttackSpeed { get; set; } = 0;
        public override float MovementSpeed { get; set; } = 4.5f;
#pragma warning disable CS0414
        private int currentCp = 1;
#pragma warning restore CS0414
        public Mantis(float healthMult, float damageMult)
        {
            Health *= healthMult;
            Damage = (int)(Damage * damageMult);
        }

        public void Awake()
        {
            Cost = 10;
            Health = 125f;
            _controller = GlobalController.instance;
            _controller.Events.EnemyTick += OnEnemyTick;
            _controller.Events.Pause += DoPause;
            //_controller.Events.EnemyTarget += OnEnemyTarget;
            GetComponentInChildren<NavMeshAgent>().angularSpeed *= 2;
            GetComponentInChildren<NavMeshAgent>().speed *= 2f;
            GetComponentInChildren<NavMeshAgent>().enabled = true;
            GetComponentInChildren<NavMeshAgent>().destination = MapHandler.instance._checkpointList[0].transform.position;
        }

        public void DoPause(object sender, EventArgs e)
        {

        }
#pragma warning disable CS0108
        public void OnEnemyTick(object sender, EventArgs e)
#pragma warning restore CS0108
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
    }
}