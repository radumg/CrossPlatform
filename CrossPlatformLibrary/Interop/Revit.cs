using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossPlatform.Interfaces;
using CrossPlatform.Geometry;
using CrossPlatform.BIM;

namespace CrossPlatform.Interop
{
    public static partial class PointInterop
    {
        public static Point FromRevit(Autodesk.Revit.DB.XYZ revitPoint)
        {
            if (revitPoint == null) throw new ArgumentNullException();

            var point = new Point
            {
                X = revitPoint.X,
                Y = revitPoint.Y,
                Z = revitPoint.Z
            };

            return point;
        }

        public static Autodesk.Revit.DB.XYZ ToRevit(Point source)
        {
            return new Autodesk.Revit.DB.XYZ(source.X, source.Y, source.Z);
        }
    }

    public static partial class LineInterop
    {
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

    }

    public static partial class WallInterop
    {
        public static Wall FromRevit(Autodesk.Revit.DB.Wall revitWall)
        {
            var wall = new Wall();
            wall.Thickness = revitWall.Width;

            // note : this will only work with unconnected walls
            // futher logic would be needed to handle the other cases
            wall.Height = revitWall.get_Parameter(Autodesk.Revit.DB.BuiltInParameter.WALL_USER_HEIGHT_PARAM).AsDouble();

            // get the base curve
            var locationCurve = revitWall.Location as Autodesk.Revit.DB.LocationCurve;
            wall.BaseLine = new Line()
            {
                StartPoint = PointInterop.FromRevit(locationCurve.Curve.GetEndPoint(0)),
                EndPoint = PointInterop.FromRevit(locationCurve.Curve.GetEndPoint(1))
            };

            return wall;
        }

        public static Autodesk.Revit.DB.Wall ToRevit(Wall source, Autodesk.Revit.DB.Document doc = null, Autodesk.Revit.DB.ElementId levelId = null)
        {
            if (doc == null || levelId == null) throw new ArgumentNullException();

            return Autodesk.Revit.DB.Wall.Create(
                doc,
                LineInterop.ToRevit(source.BaseLine),
                levelId,
                false
                );
        }

    }
}
