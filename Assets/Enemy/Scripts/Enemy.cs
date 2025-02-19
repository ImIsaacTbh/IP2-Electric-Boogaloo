using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

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

        public void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("EnemyKillVolume"))
            {
                Destroy(this.gameObject);
                _controller.Events.SendEnemyCompletedPath(Cost);
            }
        }
    }
}