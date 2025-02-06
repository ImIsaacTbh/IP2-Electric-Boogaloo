using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
    public class TowerController : MonoBehaviour
    {
        public GlobalController _controller = GlobalController.instance;
        public float _timeSinceLastTowerTick = 0f;

        void Awake()
        {
            _controller.Events.CentralTick += OnCentralTick;
        }

        public void OnCentralTick(object sender, EventArgs e)
        {
            _timeSinceLastTowerTick += Time.deltaTime;
            if (_controller.IsWaveInProgress() && _timeSinceLastTowerTick > 1/_controller._towerTickRate)
            {
                _controller.Events.SendTowerTick(EventArgs.Empty);
            }
        }
    }
}
