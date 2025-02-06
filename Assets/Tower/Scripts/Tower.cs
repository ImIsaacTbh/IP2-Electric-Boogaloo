using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Tower.Scripts
{
    public abstract class Tower : MonoBehaviour
    {
        public GlobalController _controller = GlobalController.instance;

        public abstract string Name { get; set; }
        public abstract int Cost { get; set; }
        public abstract int Damage { get; set; }
        public abstract float Range { get; set; }
        public abstract float AttackSpeed { get; set; }
        public abstract float ProjectileSpeed { get; set; }
        public abstract float ProjectileSize { get; set; }
        public abstract float ProjectileLifetime { get; set; }

        public void Start()
        {
            _controller.Events.TowerTick += OnTowerTick;
        }

        public void OnTowerTick(object sender, EventArgs e)
        {
            
        }
    }
}