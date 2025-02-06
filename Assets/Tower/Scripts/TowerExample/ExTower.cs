using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Tower.Scripts.TowerExample
{
    public class ExTower : Tower
    {
        public override string Name { get; set; }
        public override int Cost { get; set; }
        public override int Damage { get; set; }
        public override float Range { get; set; }
        public override float AttackSpeed { get; set; }
        public override float ProjectileSpeed { get; set; }
        public override float ProjectileSize { get; set; }
        public override float ProjectileLifetime { get; set; }

        public void Start()
        {
            _controller.Events.TowerTick += OnTowerTick;
        }

        public void OnTowerTick(object sender, EventArgs e)
        {
            Debug.Log("Ticked Tower");
        }
    }
}