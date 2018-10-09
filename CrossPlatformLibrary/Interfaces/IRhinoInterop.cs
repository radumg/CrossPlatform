using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatform.Interfaces
{
    interface IRhinoInterop<Tsource,Ttarget>
    {
        Tsource FromRhino(Ttarget rhinoObject);
        Ttarget ToRhino();
    }
}
