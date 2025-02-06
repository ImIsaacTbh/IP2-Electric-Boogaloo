using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
    public class EnemyController : MonoBehaviour
    {
        public GlobalController _controller = GlobalController.instance;
        public float _timeSinceLastEnemyTick = 0f;

        void Awake()
        {
            _controller.Events.CentralTick += OnCentralTick;
        }

        public void OnCentralTick(object sender, EventArgs e)
        {
            Debug.Log("Recieved Event");
            _timeSinceLastEnemyTick += Time.deltaTime;
            if (_controller.IsWaveInProgress() && _timeSinceLastEnemyTick > 1/_controller._towerTickRate)
            {
                _controller.Events.SendEnemyTick(EventArgs.Empty);
            }
        }

        void Start()
        {
            Debug.Log("Started EnemyController");
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                bool cast = Physics.Raycast(ray.origin, ray.direction, out var hit, 9999, LayerMask.NameToLayer("Ground"));
                _controller.Events.SendEnemyTarget(cast ? hit.point : new Vector3(0, 84747764, 0));
            }
        }
    }
}
