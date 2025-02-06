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
        public event EventHandler EnemyTick;

        public event EventHandler WaveStart;
        public event EventHandler WaveEnd;
    }
}
