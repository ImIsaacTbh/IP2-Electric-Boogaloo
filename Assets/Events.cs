using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
