using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatform.Interfaces
{
    interface IRevitInterop<Tsource,Ttarget>
    {
        Tsource FromRevit(Ttarget revitObject);
        Ttarget ToRevit();
        Ttarget ToRevit(Autodesk.Revit.DB.Document doc = null, Autodesk.Revit.DB.ElementId hostId=null);
    }
}
