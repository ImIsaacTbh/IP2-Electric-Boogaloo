using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

namespace Assets
{
    public class Events
    {
        public event EventHandler CentralTick;
        public virtual void SendCentralTick(EventArgs e)
        {
            CentralTick?.Invoke(this, e);
        }
        public event EventHandler TowerTick;
        public virtual void SendTowerTick(EventArgs e)
        {
            TowerTick?.Invoke(this, e);
        }
        public event EventHandler EnemyTick;
        public virtual void SendEnemyTick(EventArgs e)
        {
            EnemyTick?.Invoke(this, e);
        }

        public event EventHandler<KeyValuePair<int, Vector3>> EnemyTargetSpecific;

        public virtual void SendEnemyTargetSpecific(int id, Vector3 targetPos)
        {
            EnemyTargetSpecific?.Invoke(this, new KeyValuePair<int, Vector3>(id, targetPos));
        }
        public event EventHandler WaveStart;
        public virtual void SendWaveStart(EventArgs e)
        {
            WaveStart?.Invoke(this, e);
        }

        public event EventHandler WaveEnd;
        public virtual void SendWaveEnd(EventArgs e)
        {
            WaveEnd?.Invoke(this, e);
        }

        public event EventHandler<Vector3> EnemyTarget;
        public virtual void SendEnemyTarget(Vector3 e)
        {
            EnemyTarget?.Invoke(this, e);
        }
        public event EventHandler<int> EnemyCompletedPath;
        public virtual void SendEnemyCompletedPath(int cost)
        {
            EnemyCompletedPath?.Invoke(this, cost);
            Debug.Log($"Enemy with cost of: {cost}, completed the path.");
        }

        public event EventHandler Pause;
        public virtual void SendPause(EventArgs e)
        {
            Pause?.Invoke(this, e);
        }
        public event EventHandler UnPause;
        public virtual void SendUnPause(EventArgs e)
        {
            UnPause?.Invoke(this, e);
        }
    }
}
