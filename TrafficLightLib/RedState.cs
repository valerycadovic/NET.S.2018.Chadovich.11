using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLightLib
{
    public class RedState : IState
    {
        public string Switch(TrafficLighter lighter)
        {
            lighter.State = new YellowState();
            return "Red";
        }
    }
}
