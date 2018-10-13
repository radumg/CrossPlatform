using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossPlatform.Geometry;

namespace CrossPlatform.Interop
{
    public static class LineInterop
    {
        #region Revit
        public static Line FromRevit(Autodesk.Revit.DB.Line revitLine)
        {
            if (revitLine == null) throw new ArgumentNullException();

            var line = new Line
            {
                StartPoint = PointInterop.FromRevit(revitLine.GetEndPoint(0)),
                EndPoint = PointInterop.FromRevit(revitLine.GetEndPoint(1))
            };

            return line;
        }

        public static Autodesk.Revit.DB.Line ToRevit(Line source)
        {
            var start = PointInterop.ToRevit(source.StartPoint);
            var end = PointInterop.ToRevit(source.EndPoint);

            return Autodesk.Revit.DB.Line.CreateBound(start, end);
        }
        #endregion

        #region Rhino
        public static Line FromRhino(Rhino.Geometry.LineCurve rhinoLine)
        {
            if (rhinoLine == null) throw new ArgumentNullException();

            var line = new Line
            {
                StartPoint = PointInterop.FromRhino(rhinoLine.PointAtStart),
                EndPoint = PointInterop.FromRhino(rhinoLine.PointAtEnd)
            };

            return line;
        }

        public static Rhino.Geometry.LineCurve ToRhino(Line source)
        {
            return new Rhino.Geometry.LineCurve(PointInterop.ToRhino(source.StartPoint), PointInterop.ToRhino(source.EndPoint));
        }
        #endregion
    }
}
