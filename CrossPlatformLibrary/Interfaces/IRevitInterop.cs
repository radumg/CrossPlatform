using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatform.Interfaces
{
    // note : we didn't end up using these interfaces due to limitations on referencing Revit & Rhino DLLs
    // they could still be integrated into the project in a slightly different form though!
    interface IRevitInterop<Tsource,Ttarget>
    {
        Tsource FromRevit(Ttarget revitObject);
        Ttarget ToRevit();
    }
}
