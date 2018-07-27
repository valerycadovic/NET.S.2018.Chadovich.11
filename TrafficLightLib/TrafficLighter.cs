using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLightLib
{
    public class TrafficLighter
    {
        public IState State { get; set; }
        
        public TrafficLighter(IState state)
        {
            this.State = state ?? throw new ArgumentNullException($"{nameof(state)} is null");
        }

        public string Color { get; private set; }

        public void Switch()
        {
            Color = State.Switch(this);
        }
    }
}
