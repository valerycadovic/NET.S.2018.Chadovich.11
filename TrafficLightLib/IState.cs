using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLightLib
{
    public interface IState
    {
        string Switch(TrafficLighter lighter);
    }
}
