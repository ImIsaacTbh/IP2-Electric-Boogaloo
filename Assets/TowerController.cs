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

        void Awake()
        {
            _controller.Events.TowerTick += OnTowerTick;
        }

        public void OnTowerTick(object sender, EventArgs e)
        {
            if (_controller._isGamePaused)
            {
                return;
            }
            if (_controller.IsWaveInProgress())
            {
                //Do tower stuff
            }
        }
    }
}
